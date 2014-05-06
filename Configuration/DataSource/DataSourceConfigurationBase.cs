using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using TiramisuDataGrid.Attributes;
using TiramisuDataGrid.Common;
using TiramisuDataGrid.Configuration.Control;

namespace TiramisuDataGrid.Configuration.DataSource
{
    [Dependency(DependencyName.ControlTemplate)]
    public abstract class DataSourceConfigurationBase : IDataSourceConfiguration
    {
        #region Fields

        private BindingConfiguration bindingConfiguration;

        #endregion

        #region Constructors

        public DataSourceConfigurationBase(DataSourceMode mode)
        {
            this.Mode = mode;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public DockPanel Owner { get; set; }

        public DataSourceMode Mode { get; private set; }

        #endregion

        #region Public Methods

        public abstract void Bind(ItemsControl itemsControl, BindingConfiguration configuration);

        public abstract void AdjustBinding(ItemsControl itemsControl, BindingConfiguration configuration, string changedProperty);

        public void Attach()
        {
            this.Bind(this.GetItemsControl(), this.bindingConfiguration);

            this.RegisterSortingBehavior();
        }

        public void Detach()
        {
        }

        public void ResolveDependency(object dependency)
        {
            if (this.bindingConfiguration != null)
            {
                this.bindingConfiguration.PropertyChanged -= this.BindingConfigurationPropertyChangedHandler;
            }

            this.bindingConfiguration = this.CreatBindingConfiguration(dependency as IControlConfiguration);
        }

        public BindingConfiguration CreatBindingConfiguration(IControlConfiguration dependency)
        {
            if (dependency == null)
            {
                throw new NullReferenceException("ControlConfiguraiton is null.");
            }

            BindingConfiguration configuration;

            switch (dependency.Mode)
            {
                case ControlMode.Standard:
                    configuration = new BindingConfiguration();
                    break;
                case ControlMode.Paging:
                    configuration = new BindingConfiguration(((PagingConfiguration)dependency).Max);
                    break;
                default:
                    throw new NotSupportedException(dependency.Mode.ToString() + " is not supported yet.");
            }

            configuration.PropertyChanged += this.BindingConfigurationPropertyChangedHandler;

            return configuration;
        }

        #endregion

        #region Protected Methods

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Private Methods

        private void BindingConfigurationPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            this.bindingConfiguration = sender as BindingConfiguration;
            this.AdjustBinding(this.GetItemsControl(), this.bindingConfiguration, e.PropertyName);
        }

        private ItemsControl GetItemsControl()
        {
            return this.Owner.Children[this.Owner.Children.Count - 1] as ItemsControl;
        }

        private void RegisterSortingBehavior()
        {
            if (this.GetItemsControl() is DataGrid)
            {
                this.RegisterDataGridSortingBehavior(this.GetItemsControl() as DataGrid);
            }
            else if (this.GetItemsControl() is ListView)
            {
                throw new NotSupportedException("Do not support sorting for ListView.");
            }
            else
            {
                throw new NotSupportedException("Do not support sorting for this ItemsControl.");
            }
        }

        private void RegisterDataGridSortingBehavior(DataGrid dataGrid)
        {
            dataGrid.Sorting += (sender, e) => {

                ICollectionView dataView = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

                dataView.SortDescriptions.Clear();
                SortDescription sortDescription = new SortDescription();
                sortDescription.Direction = this.bindingConfiguration.GetSortDirection(e.Column.Header.ToString());
                sortDescription.PropertyName = e.Column.Header.ToString();
                dataView.SortDescriptions.Add(sortDescription);
                dataView.Refresh();

                e.Handled = true;
            };
        }

        #endregion
    }
}
