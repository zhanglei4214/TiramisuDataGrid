namespace TiramisuDataGrid.Configuration.DataSource
{
    public class BindingConfiguration
    {
        #region Fields

        private readonly int limit;

        #endregion

        #region Constructors

        public BindingConfiguration()
        {
            this.limit = int.MaxValue;
        }

        public BindingConfiguration(int limit)
        {
            this.limit = limit;
        }

        #endregion

        #region Properties

        public int Limit
        {
            get
            {
                return this.limit;
            }
        }

        #endregion
    }
}
