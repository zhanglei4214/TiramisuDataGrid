using System.Collections.Generic;
using System.ComponentModel;
using TiramisuDataGrid.Attributes;
using TiramisuDataGrid.Common;
using TiramisuDataGrid.Event;

namespace TiramisuDataGrid.Configuration
{
    public class ConfigurationManager
    {
        #region Fields

        private readonly List<IConfiguration> pendingQueue;

        private readonly Dictionary<DependencyName, object> resolvedDependencies;

        #endregion

        #region Constructors

        public ConfigurationManager()
        {
            this.pendingQueue = new List<IConfiguration>();

            this.resolvedDependencies = new Dictionary<DependencyName, object>();

            EventRouter.Subscribe<DependencyEvent, DependencyInfo>(this.DependencyResolvedHandler);
        }

        #endregion

        #region Public Methods

        public void Add(IConfiguration configuration)
        {
            configuration.PropertyChanged += this.ConfigurationPropertyChangedHandler;

            if (this.IsDependencyResolved(configuration) == true)
            {
                configuration.Attach();
            }
            else
            {
                this.pendingQueue.Add(configuration);
            }
        }

        public void Remove(IConfiguration configuration)
        {
            configuration.PropertyChanged -= this.ConfigurationPropertyChangedHandler;

            configuration.Detach();

            this.pendingQueue.Remove(configuration);
        }

        #endregion

        #region Private Methods

        private bool IsDependencyResolved(IConfiguration configuration)
        {
            object[] attributes = configuration.GetType().GetCustomAttributes(true);

            foreach (object attribute in attributes)
            {
                if (attribute is DependencyAttribute)
                {
                    DependencyName name = ((DependencyAttribute)attribute).Name;
                    if (this.resolvedDependencies.ContainsKey(name) == false)
                    {
                        return false;
                    }
                    else
                    {
                        if (this.resolvedDependencies[name] != null)
                        {
                            configuration.ResolveDependency(this.resolvedDependencies[name]);
                        }
                    }
                }
            }

            return true;
        }

        private void ConfigurationPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
        }

        private void DependencyResolvedHandler(DependencyInfo dependency)
        {
            if (this.resolvedDependencies.ContainsKey(dependency.Name) == true)
            {
                return;
            }

            this.resolvedDependencies[dependency.Name] = dependency.Value;

            this.ContinueReadyConfiguration();
        }

        private void ContinueReadyConfiguration()
        {
            List<IConfiguration> resolved = new List<IConfiguration>();

            foreach (IConfiguration configuration in this.pendingQueue)
            {
                if (this.IsDependencyResolved(configuration) == true)
                {
                    resolved.Add(configuration);
                }
            }

            resolved.ForEach(configuration => this.pendingQueue.Remove(configuration));

            resolved.ForEach(configuration => configuration.Attach());

            resolved.Clear();
        }

        #endregion
    }
}
