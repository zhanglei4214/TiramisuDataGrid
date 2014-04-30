using System.Collections;
using System.Windows;
using System.Windows.Controls;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.Control
{
    public class PagingController : IControlInitializer, IBindingAdjuster
    {
        #region Constructors

        public PagingController()
        {
        }

        #endregion

        #region Public Methods

        public void Initialize(TiramisuDataGrid container)
        {
            StackPanel panel = this.CreatePagingPanel();
            DockPanel.SetDock(panel, Dock.Bottom);

            container.Children.Add(panel);

        }

        public IEnumerable Adjust(object original, RenderConfiguration renderConfiguration, AdjustConfiguration adjustConfiguration)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Private Methods

        private StackPanel CreatePagingPanel()
        {
            StackPanel panel = new StackPanel();

            panel.Orientation = Orientation.Horizontal;
            panel.HorizontalAlignment = HorizontalAlignment.Center;
            panel.Margin = new Thickness(0, 5, 0, 3);

            Button prev = new Button();
            prev.Content = "Pre";
            
            Button next = new Button();
            next.Content = "Next";

            panel.Children.Add(prev);

            panel.Children.Add(next);

            return panel;
        }

        private Button CreateImageButton(int height, int width, Image image)
        {
            Button button = new Button();
            button.Height = height;
            button.Width = width;

            button.Content = image;

            return button;
        }

        #endregion
    }
}
