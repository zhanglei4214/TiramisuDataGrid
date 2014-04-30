using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.DataSource;

namespace TiramisuDataGrid.Virtualization
{
    public interface IVirtualizer
    {
        #region Properties

        ChangeObserver Observer { get; }

        #endregion

        #region Public Methods

        void Update();

        void Assign(IDataSourceProvider provider, RenderConfiguration configuration);

        #endregion
    }
}
