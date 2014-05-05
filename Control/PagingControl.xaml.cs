using System.Windows.Controls;
using System.Windows.Input;
using TiramisuDataGrid.Common;
using TiramisuDataGrid.Event;

namespace TiramisuDataGrid.Control
{
    /// <summary>
    /// Interaction logic for PagingControl.xaml
    /// </summary>
    public partial class PagingControl : StackPanel
    {
        #region Constructors

        public PagingControl()
        {
            InitializeComponent();

            this.DataContext = this;

            this.InitializeCommand();
        }

        #endregion

        #region Properties

        public ICommand GoPrevious { get; private set; }

        public ICommand GoNext { get; private set; }

        #endregion

        #region Private Methods

        private void InitializeCommand()
        {
            this.GoPrevious = new DelegateCommand(this.GoPreviousHandler, this.CanGoPreviousHandler);

            this.GoNext = new DelegateCommand(this.GoNextHandler, this.CanGoNextHandler);
        }

        private void GoPreviousHandler(object obj)
        {
            EventRouter.Publish<PageChangeEvent, PageOption>(PageOption.Previous);
        }

        private bool CanGoPreviousHandler(object obj)
        {
            return true;
        }

        private void GoNextHandler(object obj)
        {
            EventRouter.Publish<PageChangeEvent, PageOption>(PageOption.Next);
        }

        private bool CanGoNextHandler(object obj)
        {
            return true;
        }

        #endregion

    }
}
