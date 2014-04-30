using System.ComponentModel;

namespace TiramisuDataGrid.Configuration
{
    public class PagingRenderConfiguration : INotifyPropertyChanged
    {
        #region Fields

        private int max;

        #endregion

        #region Constructors

        public PagingRenderConfiguration()
        {
            this.Max = 200;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public int Max
        {
            get
            {
                return this.max;
            }

            set
            {
                this.max = value;
                this.NotifyPropertyChanged("Max");
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Handles notifying of a property changed.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
