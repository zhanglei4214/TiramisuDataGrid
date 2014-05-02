using System.Windows;
using System.Windows.Controls;
using TiramisuDataGrid.Control;

namespace TiramisuDataGrid.Configuration.Control
{
    public class ControlConfigurationBase : ConfigurationBase, IControlConfiguration
    {        
        #region Constructors

        public ControlConfigurationBase(ControlMode mode)
            : base("ControlConfiguration")
        {
            this.Mode = mode;
        }

        #endregion

        #region Properties

        public ControlMode Mode { get; private set; }

        #endregion

        #region Public Methods

        public override void Attach()
        {
            base.Attach();

            this.UpdateLayout();                   
        }

        public override void Detach()
        {
            base.Detach();
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
