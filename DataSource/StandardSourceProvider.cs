using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.DataSource
{
    public class StandardSourceProvider<T> : DataSourceProviderBase
    {
        #region Fields

        private readonly ObservableCollection<T> source;

        #endregion

        #region Constructors

        public StandardSourceProvider(ObservableCollection<T> source)
            : base(SourceType.Standard)
        {
            this.source = source;
        }

        #endregion

        #region Protected Methods

        protected override void DoBind(object target, IEnumerable source)
        {
            TiramisuDataGrid container = target as TiramisuDataGrid;

            DataGrid dataGrid = container.Children[container.Children.Count-1] as DataGrid;

            dataGrid.ItemsSource = source;
        }

        protected override object GetSource()
        {
            return this.source;
        }

        #endregion        
    }
}
