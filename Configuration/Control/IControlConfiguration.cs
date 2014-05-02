using System.Windows.Controls;

namespace TiramisuDataGrid.Configuration.Control
{
    public interface IControlConfiguration : IConfiguration
    {
        ControlMode Mode { get; }
    }
}
