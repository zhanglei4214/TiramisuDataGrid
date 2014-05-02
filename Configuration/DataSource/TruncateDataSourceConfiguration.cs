using System.Collections.ObjectModel;
using TiramisuDataGrid.DataSource;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public class TruncateDataSourceConfiguration<T> : InMemoryDataSourceConfiguration<T>
    {
        #region Constructors

        public TruncateDataSourceConfiguration(ObservableCollection<T> collection)
            : base(DataSourceMode.Truncate, collection)
        {
        }

        #endregion
    }
}
