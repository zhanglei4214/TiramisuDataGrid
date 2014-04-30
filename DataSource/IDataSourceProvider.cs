using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.Control;

namespace TiramisuDataGrid.DataSource
{
    public interface IDataSourceProvider
    {
        #region Properties

        SourceType SourceType { get; }

        object Source { get; }

        IBindingAdjuster Adjuster { get; }

        #endregion

        #region Public Methods

        void Bind(object target, RenderConfiguration configuration);

        #endregion
    }
}
