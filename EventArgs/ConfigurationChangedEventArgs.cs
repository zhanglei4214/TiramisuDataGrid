using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.EventArgs
{
    public class ConfigurationChangedEventArgs : System.EventArgs
    {
        #region Fields

        private readonly IConfiguration configuration;

        private readonly ConfigurationChangeAction action;

        #endregion

        #region Constructors

        public ConfigurationChangedEventArgs(IConfiguration configuration, ConfigurationChangeAction action)
        {
            this.configuration = configuration;

            this.action = action;
        }

        #endregion

        #region Properties

        public IConfiguration Configuration
        {
            get
            {
                return this.configuration;
            }
        }

        public ConfigurationChangeAction Action
        {
            get
            {
                return this.action;
            }
        }

        #endregion
    }
}
