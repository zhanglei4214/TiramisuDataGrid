using System.Windows;
using System.Windows.Controls;
using TiramisuDataGrid.Attributes;
using TiramisuDataGrid.Common;
using TiramisuDataGrid.Configuration.Control;
using TiramisuDataGrid.Configuration.DataSource;
using TiramisuDataGrid.EventArgs;
using TiramisuDataGrid.Virtualization;

namespace TiramisuDataGrid
{
    public class TiramisuDataGrid : DockPanel
    {        
        #region Dependency Properties

        public static readonly DependencyProperty ControlTemplateProperty = DependencyProperty.Register("ControlTemplate", typeof(IControlConfiguration), typeof(TiramisuDataGrid), new PropertyMetadata(new StandardConfiguration(), OnControlTemplateChanged));

        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register("DataSource", typeof(IDataSourceConfiguration), typeof(TiramisuDataGrid), new PropertyMetadata(null, OnDataSourceChanged));

        #endregion

        #region Fields

        private readonly Proxy proxy;

        #endregion

        #region Constructors

        public TiramisuDataGrid()
        {
            this.proxy = new Proxy(this);
        }

        #endregion

        #region Properties

        public IControlConfiguration ControlTemplate
        {
            get
            {
                return (IControlConfiguration)GetValue(ControlTemplateProperty);
            }

            set
            {
                SetValue(ControlTemplateProperty, value);
            }
        }

        public IDataSourceConfiguration DataSource
        {
            get
            {
                return (IDataSourceConfiguration)GetValue(DataSourceProperty);
            }

            set
            {                
                SetValue(DataSourceProperty, value);                            
            }
        }

        #endregion        

        protected override void OnInitialized(System.EventArgs e)
        {
            base.OnInitialized(e);

            EventRouter.Publish<DependencyEvent, DependencyInfo>(new DependencyInfo(DependencyName.LayoutInitialized));
        }

        #region Private Methods

        private static void OnDataSourceChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TiramisuDataGrid me = sender as TiramisuDataGrid;

            if (me == null)
            {
                return;
            }

            IDataSourceConfiguration newValue = e.NewValue as IDataSourceConfiguration;
            IDataSourceConfiguration oldValue = e.OldValue as IDataSourceConfiguration;

            if (oldValue != null)
            {
                me.proxy.Detach(oldValue);
            }

            if (newValue != null)
            {
                me.proxy.Attach(newValue);
            }

            me.DataSource = newValue;
        }

        private static void OnControlTemplateChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TiramisuDataGrid me = sender as TiramisuDataGrid;

            if (me == null)
            {
                return;
            }

            IControlConfiguration newValue = e.NewValue as IControlConfiguration;
            IControlConfiguration oldValue = e.OldValue as IControlConfiguration;

            if (oldValue != null)
            {
                me.proxy.Detach(oldValue);
            }

            if (newValue != null)
            {
                me.proxy.Attach(newValue);
            }

            me.ControlTemplate = newValue;
        }

        #endregion
    }
}
