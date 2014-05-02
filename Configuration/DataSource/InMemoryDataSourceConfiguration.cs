using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using TiramisuDataGrid.DataSource;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public class InMemoryDataSourceConfiguration<T> : DataSourceConfigurationBase
    {
        #region Fields

        private readonly ObservableCollection<T> collection;

        #endregion

        #region Constructors

        public InMemoryDataSourceConfiguration(ObservableCollection<T> collection)
            : this(DataSourceMode.Default, collection)
        {
        }

        public InMemoryDataSourceConfiguration(DataSourceMode mode, ObservableCollection<T> collection)
            : base(mode)
        {
            this.collection = collection;
        }

        #endregion

        #region Properties

        public ObservableCollection<T> Collection
        {
            get
            {
                return this.collection;
            }
        }

        #endregion

        #region Public Methods

        public override void Bind()
        {
            //// TODO: Needs to enhance.
            ((DataGrid)this.Owner.Children[this.Owner.Children.Count - 1]).ItemsSource = this.collection;
        }

        #endregion
    }
}
