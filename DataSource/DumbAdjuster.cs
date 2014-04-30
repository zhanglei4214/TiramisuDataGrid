using System.Collections;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.Control
{
    public class DumbAdjuster : IBindingAdjuster
    {
        public IEnumerable Adjust(object original, RenderConfiguration renderConfiguration, AdjustConfiguration adjustConfiguration)
        {
            return original as IEnumerable;
        }
    }
}
