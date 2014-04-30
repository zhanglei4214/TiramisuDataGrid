using System;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.Control
{
    public class BindingAdjusterFactory
    {
        #region Constructors

        private BindingAdjusterFactory()
        {
        }

        #endregion

        #region Public Methods

        public static IBindingAdjuster Create(RenderMode mode)
        {
            switch (mode)
            {
                case RenderMode.Standard:
                    return new DumbAdjuster();
                case RenderMode.Paging:
                    return new PagingAdjuster();
                default:
                    throw new NotSupportedException("Not supported yet.");
            }
        }

        #endregion
    }
}
