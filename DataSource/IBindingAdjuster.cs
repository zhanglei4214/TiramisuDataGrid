using System.Collections;
using TiramisuDataGrid.Configuration.DataSource;

namespace TiramisuDataGrid.DataSource
{
    public interface IBindingAdjuster
    {
        IEnumerable Adjust(object original, AdjustConfiguration configuration);
    }
}
