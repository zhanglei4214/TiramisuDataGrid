namespace TiramisuDataGrid.Common
{
    public class DependencyInfo
    {
        #region Fields

        private readonly DependencyName name;

        private readonly object value;

        #endregion

        #region Constructors

        public DependencyInfo(DependencyName name)
            : this(name, null)
        {
        }

        public DependencyInfo(DependencyName name, object value)
        {
            this.name = name;
            this.value = value;
        }

        #endregion

        #region Properties

        public DependencyName Name
        {
            get
            {
                return this.name;
            }
        }

        public object Value
        {
            get
            {
                return this.value;
            }
        }

        #endregion
    }
}
