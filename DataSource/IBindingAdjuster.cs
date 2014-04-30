using System.Collections;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.Control
{
    public interface IBindingAdjuster
    {
        IEnumerable Adjust(object original, RenderConfiguration renderConfiguration, AdjustConfiguration adjustConfiguration);
    }
}
