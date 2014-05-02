
namespace TiramisuDataGrid.Configuration.DataSource
{
    public class AdjustConfiguration
    {
        #region Fields

        private readonly IDataSourceConfiguration configuration;

        #endregion

        #region Constructors

        public AdjustConfiguration(IDataSourceConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion
    }
}
