using System.Collections.Generic;
using TiramisuDataGrid.Attributes;

namespace TiramisuDataGrid.Configuration
{
    public class ConfigurationManager
    {
        #region Fields

        private readonly Dictionary<IConfiguration, ConfigurationMetaData> memo;

        private readonly Dictionary<IConfiguration, bool> pendingQueue;

        #endregion

        #region Constructors

        public ConfigurationManager()
        {
            this.memo = new Dictionary<IConfiguration, ConfigurationMetaData>();

            this.pendingQueue = new Dictionary<IConfiguration, bool>();
        }

        #endregion

        #region Public Methods

        public void Add(IConfiguration configuration)
        {
            this.memo[configuration] = new ConfigurationMetaData(configuration);

            this.AddDependency(configuration);

            if (this.memo[configuration].DependencySolved == true)
            {
                configuration.Attach();
            }
            else
            {
                this.pendingQueue.Add(configuration, true);
            }

            this.SolveDependency(configuration);
        }

        public void Remove(IConfiguration configuration)
        {
            configuration.Detach();

            this.memo.Remove(configuration);
        }

        #endregion

        #region Private Methods

        private void SolveDependency(IConfiguration dependency)
        {
            foreach (var meta in this.memo)
            {
                if (meta.Key.Name == dependency.Name)
                {
                    continue;
                }

                meta.Value.SolveDependency(dependency);

                if (meta.Value.DependencySolved == true && this.pendingQueue.ContainsKey(meta.Key) == true)
                {
                    meta.Key.Attach();

                    this.pendingQueue.Remove(meta.Key);
                }
            }
        }

        private void AddDependency(IConfiguration configuration)
        {
            object[] attributes = configuration.GetType().GetCustomAttributes(true);

            foreach (object attribute in attributes)
            {
                if (attribute is DependencyAttribute)
                {
                    this.memo[configuration].AddDependency(((DependencyAttribute)attribute).Name);
                }
            }
        }

        #endregion
    }
}
