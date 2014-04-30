using System.ComponentModel;

namespace TiramisuDataGrid.Configuration
{
    public class RenderConfiguration : INotifyPropertyChanged
    {
        #region Dependency Properties

        private PagingRenderConfiguration paging;

        private RenderMode mode;

        #endregion

        #region Constructors

        public RenderConfiguration()            
        {
            this.Mode = RenderMode.Standard;
        }

        public RenderConfiguration(RenderMode mode)
        {
            this.Mode = mode;

            this.Paging = new PagingRenderConfiguration();
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public RenderMode Mode
        {
            get
            {
                return this.mode;
            }

            set
            {
                this.mode = value;
                this.NotifyPropertyChanged("Mode");
            }
        }

        public PagingRenderConfiguration Paging
        {
            get
            {
                return this.paging;
            }

            set
            {
                this.paging = value;
                this.NotifyPropertyChanged("Paging");
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
