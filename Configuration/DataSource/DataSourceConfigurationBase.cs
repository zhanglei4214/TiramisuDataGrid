using System;
using System.ComponentModel;
using TiramisuDataGrid.Attributes;
using TiramisuDataGrid.Configuration.Control;

namespace TiramisuDataGrid.Configuration.DataSource
{
    [Dependency("ControlConfiguration")]
    public abstract class DataSourceConfigurationBase : ConfigurationBase, IDataSourceConfiguration
    {
        #region Fields

        private BindingConfiguration bindingConfiguration;

        #endregion

        #region Constructors

        public DataSourceConfigurationBase(DataSourceMode mode)
            : base("DataSourceConfiguration")
        {
            this.Mode = mode;
        }

        #endregion

        #region Properties

        public DataSourceMode Mode { get; private set; }

        #endregion

        #region Public Methods

        public abstract void Bind(BindingConfiguration configuration);

        public abstract void AdjustBinding(BindingConfiguration configuration, string changedProperty);

        public override void Attach()
        {
            base.Attach();

            this.Bind(this.bindingConfiguration);
        }

        public override void Detach()
        {
            base.Detach();
        }

        public override void SolveDependency(IConfiguration dependency)
        {
            base.SolveDependency(dependency);

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

        private void BindingConfigurationPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            this.AdjustBinding(sender as BindingConfiguration, e.PropertyName);
        }

        #endregion
    }
}
