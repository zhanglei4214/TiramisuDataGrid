using System.Windows.Controls;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public interface IDataSourceConfiguration : IConfiguration
    {
        DataSourceMode Mode { get; }
    }
}
