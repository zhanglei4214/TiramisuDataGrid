using System.Windows.Controls;
using TiramisuDataGrid.Attributes;
using TiramisuDataGrid.DataSource;

namespace TiramisuDataGrid.Configuration.DataSource
{
    [Dependency("ControlConfiguration")]
    public abstract class DataSourceConfigurationBase : ConfigurationBase, IDataSourceConfiguration
    {
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

        public abstract void Bind();

        public override void Attach()
        {
            base.Attach();

            this.Bind();
        }

        public override void Detach()
        {
            base.Detach();
        }        

        #endregion
    }
}
