using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.DataSource;
using TiramisuDataGrid.Virtualization;

namespace TiramisuDataGrid
{
    public class TiramisuDataGrid : DockPanel
    {        
        #region Dependency Properties
        
        public static readonly DependencyProperty RenderConfigurationProperty = DependencyProperty.Register("RenderConfiguration", typeof(RenderConfiguration), typeof(TiramisuDataGrid), new PropertyMetadata(new RenderConfiguration(RenderMode.Paging), OnRenderConfigurationChanged));

        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register("DataSource", typeof(IDataSourceProvider), typeof(TiramisuDataGrid), new PropertyMetadata(null, OnDataSourceChanged));

        #endregion

        #region Fields

        private IVirtualizer virtualizer;

        #endregion

        #region Constructors

        public TiramisuDataGrid()
        {
            this.AddHandler(ScrollViewer.ScrollChangedEvent, new ScrollChangedEventHandler(this.ScrollChangedHandler));

            this.InitializeVirtualizer();
        }

        #endregion

        #region Properties

        public RenderConfiguration RenderConfiguration
        {
            get
            {
                return (RenderConfiguration)GetValue(RenderConfigurationProperty);
            }

            set
            {
                SetValue(RenderConfigurationProperty, value);

                this.virtualizer.Observer.Configuration = value;
            }
        }

        public IDataSourceProvider DataSource
        {
            get
            {
                return (IDataSourceProvider)GetValue(DataSourceProperty);
            }

            set
            {
                SetValue(DataSourceProperty, value);

                this.virtualizer.Observer.DataSource = value;
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnRender(DrawingContext drawingContext)
        {
            DateTime start = DateTime.Now;

            base.OnRender(drawingContext);

            DateTime end = DateTime.Now;            

            this.LoggingBenchmarkTest(end - start);
        }

        #endregion

        #region Private Methods

        #region Dependecy Property Changed Event Handlers

        private static void OnDataSourceChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TiramisuDataGrid me = sender as TiramisuDataGrid;

            if (me == null)
            {
                return;
            }

            IDataSourceProvider dataSource = e.NewValue as IDataSourceProvider;

            if (dataSource == null)
            {
                return;
            }

            me.DataSource = dataSource;
        }

        private static void OnRenderConfigurationChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TiramisuDataGrid me = sender as TiramisuDataGrid;

            if (me == null)
            {
                return;
            }

            RenderConfiguration configuration = e.NewValue as RenderConfiguration;

            if (configuration == null)
            {
                throw new NullReferenceException("RenderConfiguration cannot be null.");
            }

            me.RenderConfiguration = configuration;
        }

        #endregion

        private void InitializeVirtualizer()
        {
            this.virtualizer = new Virtualizer(this);
        }

        private void ScrollChangedHandler(object sender, ScrollChangedEventArgs e)
        {
            this.virtualizer.Update();
        }        

        #region Benchmark Logging

        private void LoggingBenchmarkTest(TimeSpan duration)
        {            
            //// TODO: add more logic.
        }

        #endregion

        #endregion
    }
}
