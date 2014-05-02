using System;
using System.Windows;
using System.Windows.Controls;

namespace TiramisuDataGrid.Control
{
    public class ControlFactory
    {
        #region Constructors

        private ControlFactory()
        {
        }

        #endregion

        #region Public Methods

        public static UIElement Create(string mode)
        {
            switch (mode)
            {
                case "Standard":
                    return new StackPanel();
                case "Paging":
                    return new PagingControl();
                default:
                    throw new NotSupportedException("mode " + mode.ToString() + " not supported.");
            }
        }

        #endregion
    }
}
