using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public class InMemoryDataSourceConfiguration<T> : DataSourceConfigurationBase<T>
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

        #region Public Methods

        public override IEnumerable<T> LoadFromOriginalSource(BindingConfiguration configuration)
        {
            return this.collection;
        }

        #endregion
    }
}
