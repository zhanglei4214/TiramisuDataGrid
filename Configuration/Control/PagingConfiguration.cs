namespace TiramisuDataGrid.Configuration.Control
{
    public class PagingConfiguration : ControlConfigurationBase
    {
        #region Fields

        private int max;

        #endregion

        #region Constructors

        public PagingConfiguration(int max)
            : base(ControlMode.Paging)
        {
            this.Max = max;
        }

        public PagingConfiguration()
            : this(50)
        {
        }

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
    }
}
