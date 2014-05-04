using System;
using System.Windows.Input;

namespace TiramisuDataGrid.Common
{
    public class DelegateCommand : ICommand
    {
        #region Fields

        private readonly Predicate<object> canExecute;

        private readonly Action<object> execute;

        #endregion

        #region Constructors

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Public Methods

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }

            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, System.EventArgs.Empty);
            }
        }

        #endregion
    }
}
