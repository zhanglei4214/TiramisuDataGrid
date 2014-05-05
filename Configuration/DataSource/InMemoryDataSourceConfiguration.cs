using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public class InMemoryDataSourceConfiguration<T> : DataSourceConfigurationBase
    {
        #region Fields

        private readonly ObservableCollection<T> collection;

        #endregion

        #region Constructors

        public InMemoryDataSourceConfiguration(ObservableCollection<T> collection)
            : this(DataSourceMode.InMemory, collection)
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

        public override void Bind(BindingConfiguration configuration)
        {            
            int index = this.GetDataGridIndex();

            if (configuration.Limit == int.MaxValue)
            {
                ((DataGrid)this.Owner.Children[index]).ItemsSource = this.collection;
            }
            else
            {
                ((DataGrid)this.Owner.Children[index]).ItemsSource = this.collection.Take(configuration.Limit);
            }
        }

        public override void AdjustBinding(BindingConfiguration configuration, string changedProperty)
        {
            if (changedProperty == "Skip")
            {
                int index = this.GetDataGridIndex();
                ((DataGrid)this.Owner.Children[index]).ItemsSource = this.collection.Skip(configuration.Skip).Take(configuration.Limit);
            }
        }

        #endregion

        #region Private Methods

        private int GetDataGridIndex()
        {
            //// TODO: Needs to enhance.
            return this.Owner.Children.Count - 1;
        }

        #endregion
    }
}
