using System;
using System.Windows;
using System.Windows.Controls;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.Control
{
    public class ControlManager
    {
        #region Fields

        #endregion

        #region Constructors

        private ControlManager()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        public static void Update(TiramisuDataGrid container, RenderMode mode)
        {
            UIElement element = container.Children[0];
            container.Children.Clear();

            ControlFactory.Create(mode.ToString()).Initialize(container);

            container.Children.Add(element);

            container.LastChildFill = true;
        }

        public static void Verify(UIElementCollection elements)
        {
            if (elements.Count != 1)
            {
                throw new Exception("StandardDataGrid must have one DataGrid instance.");
            }

            VerifyDataGrid(elements[0]);
        }

        #endregion

        #region Private Methods

        private static void VerifyDataGrid(UIElement element)
        {
            DataGrid dataGrid = element as DataGrid;

            if (dataGrid == null)
            {
                throw new Exception("StandardDataGrid must have DataGrid instance.");
            }
        }

        #endregion
    }
}
