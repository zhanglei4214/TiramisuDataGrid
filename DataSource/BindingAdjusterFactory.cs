using System;
using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.Configuration.DataSource;

namespace TiramisuDataGrid.DataSource
{
    public class BindingAdjusterFactory
    {
        #region Constructors

        private BindingAdjusterFactory()
        {
        }

        #endregion

        #region Public Methods

        public static IBindingAdjuster Create(DataSourceMode mode)
        {
            switch (mode)
            {
                case DataSourceMode.Default:
                    return new DumbAdjuster();
                case DataSourceMode.Truncate:
                    return new PagingAdjuster();
                default:
                    throw new NotSupportedException("Not supported yet.");
            }
        }

        #endregion
    }
}