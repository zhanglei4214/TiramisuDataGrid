using System.Windows.Controls;
using TiramisuDataGrid.Configuration.Control;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public interface IDataSourceConfiguration : IConfiguration
    {
        DataSourceMode Mode { get; }

        BindingConfiguration CreatBindingConfiguration(IControlConfiguration dependency);
    }
}
