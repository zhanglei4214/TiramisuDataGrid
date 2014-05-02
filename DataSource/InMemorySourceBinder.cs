using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.DataSource
{
    public class InMemorySourceBinder<T> 
    {
        #region Fields

        #endregion

        #region Constructors

        public InMemorySourceBinder()
        {
        }

        #endregion

        #region Protected Methods

        protected void DoBind(object target, IEnumerable source)
        {
            TiramisuDataGrid container = target as TiramisuDataGrid;

            DataGrid dataGrid = container.Children[container.Children.Count-1] as DataGrid;

            dataGrid.ItemsSource = source;
        }

        #endregion        
    }
}
