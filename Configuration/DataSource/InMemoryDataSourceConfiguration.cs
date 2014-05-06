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

        public override void Bind(ItemsControl itemsControl, BindingConfiguration configuration)
        {                        
            if (configuration.Limit == int.MaxValue)
            {
                itemsControl.ItemsSource = this.collection;
            }
            else
            {
                itemsControl.ItemsSource = this.collection.Take(configuration.Limit);
            }
        }

        public override void AdjustBinding(ItemsControl itemsControl, BindingConfiguration configuration, string changedProperty)
        {
            if (changedProperty == "Skip")
            {                
                itemsControl.ItemsSource = this.collection.Skip(configuration.Skip).Take(configuration.Limit);
            }
        }

        #endregion
    }
}
