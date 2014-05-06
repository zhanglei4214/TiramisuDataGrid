using System;
using System.ComponentModel;
using TiramisuDataGrid.Common;
using TiramisuDataGrid.Control;
using TiramisuDataGrid.Event;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public class BindingConfiguration : INotifyPropertyChanged
    {
        #region Fields

        private int limit;

        private int skip;

        #endregion

        #region Constructors

        public BindingConfiguration()
            : this(int.MaxValue)
        {
        }

        public BindingConfiguration(int limit)
        {
            this.Limit = limit;
            this.Skip = 0;

            this.HookEvents();
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public int Limit
        {
            get
            {
                return this.limit;
            }

            set
            {
                this.limit = value;
                this.NotifyPropertyChanged("Limit");
            }
        }

        public int Skip
        {
            get
            {
                return this.skip;
            }

            set
            {
                this.skip = value;
                this.NotifyPropertyChanged("Skip");
            }
        }

        #endregion

        #region Private Methods

        private void HookEvents()
        {
            EventRouter.Subscribe<PageChangeEvent, PageOption>(this.PageChangeEventHandler);
        }

        private void PageChangeEventHandler(PageOption option)
        {
            switch (option)
            {
                case PageOption.Previous:
                    this.Skip = this.Skip - this.Limit < 0 ? 0 : this.Skip - this.Limit;
                    break;
                case PageOption.Next:
                    this.Skip += this.Limit;
                    break;
                default:
                    throw new NotSupportedException(option.ToString() + " is not supported.");
            }
        }

        /// <summary>
        /// Handles notifying of a property changed.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
