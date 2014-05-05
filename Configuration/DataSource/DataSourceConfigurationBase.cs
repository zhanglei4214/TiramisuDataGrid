using System;
using System.ComponentModel;
using System.Windows.Controls;
using TiramisuDataGrid.Attributes;
using TiramisuDataGrid.Common;
using TiramisuDataGrid.Configuration.Control;

namespace TiramisuDataGrid.Configuration.DataSource
{
    [Dependency(DependencyName.ControlTemplate)]
    public abstract class DataSourceConfigurationBase : IDataSourceConfiguration
    {
        #region Fields

        private BindingConfiguration bindingConfiguration;

        #endregion

        #region Constructors

        public DataSourceConfigurationBase(DataSourceMode mode)
        {
            this.Mode = mode;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public DockPanel Owner { get; set; }

        public DataSourceMode Mode { get; private set; }

        #endregion

        #region Public Methods

        public abstract void Bind(BindingConfiguration configuration);

        public abstract void AdjustBinding(BindingConfiguration configuration, string changedProperty);

        public void Attach()
        {
            this.Bind(this.bindingConfiguration);
        }

        public void Detach()
        {
        }

        public void ResolveDependency(object dependency)
        {
            if (this.bindingConfiguration != null)
            {
                this.bindingConfiguration.PropertyChanged -= this.BindingConfigurationPropertyChangedHandler;
            }

            this.bindingConfiguration = this.CreatBindingConfiguration(dependency as IControlConfiguration);
        }

        public BindingConfiguration CreatBindingConfiguration(IControlConfiguration dependency)
        {
            if (dependency == null)
            {
                throw new NullReferenceException("ControlConfiguraiton is null.");
            }

            BindingConfiguration configuration;

            switch (dependency.Mode)
            {
                case ControlMode.Standard:
                    configuration = new BindingConfiguration();
                    break;
                case ControlMode.Paging:
                    configuration = new BindingConfiguration(((PagingConfiguration)dependency).Max);
                    break;
                default:
                    throw new NotSupportedException(dependency.Mode.ToString() + " is not supported yet.");
            }

            configuration.PropertyChanged += this.BindingConfigurationPropertyChangedHandler;

            return configuration;
        }

        #endregion

        #region Protected Methods

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void BindingConfigurationPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            this.AdjustBinding(sender as BindingConfiguration, e.PropertyName);
        }

        #endregion
    }
}
