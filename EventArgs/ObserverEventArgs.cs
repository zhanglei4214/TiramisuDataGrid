using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.DataSource;

namespace TiramisuDataGrid.EventArgs
{
    public enum ArgumentType
    {
        Configuration,

        DataSource,

        Both
    }

    public class ObserverEventArgs : System.EventArgs
    {
        #region Fields

        private readonly RenderConfiguration configuration;

        private readonly IDataSourceProvider source;

        private readonly ArgumentType type;

        #endregion

        #region Constructors

        public ObserverEventArgs(ArgumentType type, RenderConfiguration configuration, IDataSourceProvider source)
        {
            this.type = type;

            this.configuration = configuration;
            this.source = source;
        }

        #endregion

        #region Properties

        public ArgumentType ChangedType
        {
            get
            {
                return this.type;
            }
        }

        public RenderConfiguration Configuration
        {
            get
            {
                return this.configuration;
            }
        }

        public IDataSourceProvider DataSource
        {
            get
            {
                return this.source;
            }
        }

        #endregion
    }
}
