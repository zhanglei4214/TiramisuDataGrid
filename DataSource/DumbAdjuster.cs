using System.Collections;
using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.Configuration.DataSource;

namespace TiramisuDataGrid.DataSource
{
    public class DumbAdjuster : IBindingAdjuster
    {
        public IEnumerable Adjust(object original, AdjustConfiguration configuration)
        {
            return original as IEnumerable;
        }
    }
}
