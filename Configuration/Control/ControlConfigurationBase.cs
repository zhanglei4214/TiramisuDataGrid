using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TiramisuDataGrid.Attributes;
using TiramisuDataGrid.Common;
using TiramisuDataGrid.Control;
using TiramisuDataGrid.Event;

namespace TiramisuDataGrid.Configuration.Control
{
    [Dependency(DependencyName.LayoutInitialized)]
    public class ControlConfigurationBase : IControlConfiguration
    {        
        #region Constructors

        public ControlConfigurationBase(ControlMode mode)
        {
            this.Mode = mode;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public DockPanel Owner { get; set; }

        public ControlMode Mode { get; private set; }

        #endregion

        #region Public Methods

        public void Attach()
        {
            this.UpdateLayout();

            EventRouter.Publish<DependencyEvent, DependencyInfo>(new DependencyInfo(DependencyName.ControlTemplate, this));             
        }

        public void Detach()
        {
        }

        public void ResolveDependency(object dependency)
        {
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

        private void UpdateLayout()
        {
            UIElement element = this.Owner.Children[0];
            this.Owner.Children.Clear();

            UIElement panel = ControlFactory.Create(this.Mode.ToString());
            DockPanel.SetDock(panel, Dock.Bottom);
            this.Owner.Children.Add(panel);

            DockPanel.SetDock(element, Dock.Top);

            this.Owner.Children.Add(element);

            this.Owner.LastChildFill = true;
        }

        #endregion
    }
}
