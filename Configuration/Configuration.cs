using System.ComponentModel;
using TiramisuDataGrid.Configuration.Control;
using TiramisuDataGrid.Configuration.DataSource;

namespace TiramisuDataGrid.Configuration
{
    public class Configuration : ConfigurationBase
    {
        #region Dependency Properties

        private IControlConfiguration controlConfiguration;

        private IDataSourceConfiguration dataSourceConfiguration;

        private Mode mode;

        #endregion

        #region Constructors

        public Configuration(Mode mode, IControlConfiguration controlConfiguration, IDataSourceConfiguration dataSourceConfiguration)
            : base("Configuration")
        {
            this.mode = mode;

            this.controlConfiguration = controlConfiguration;
            this.dataSourceConfiguration = dataSourceConfiguration;
        }

        #endregion

        #region Properties

        public Mode Mode
        {
            get
            {
                return this.mode;
            }

            set
            {
                this.mode = value;
                this.NotifyPropertyChanged("Mode");
            }
        }

        public IControlConfiguration ControlConfiguration
        {
            get
            {
                return this.controlConfiguration;
            }

            set
            {
                this.controlConfiguration = value;
                this.NotifyPropertyChanged("ControlConfiguration");
            }
        }

        public IDataSourceConfiguration DataSourceConfiguration
        {
            get
            {
                return this.dataSourceConfiguration;
            }

            set
            {
                this.dataSourceConfiguration = value;
                this.NotifyPropertyChanged("DataSourceConfiguration");    
            }
        }

        #endregion
    }
}
