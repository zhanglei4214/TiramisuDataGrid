using System.ComponentModel;
using TiramisuDataGrid.Converters;

namespace TiramisuDataGrid.Configuration.Control
{
    [TypeConverter(typeof(ControlTypeConverter))]
    public interface IControlConfiguration : IConfiguration
    {
        ControlMode Mode { get; }
    }
}
