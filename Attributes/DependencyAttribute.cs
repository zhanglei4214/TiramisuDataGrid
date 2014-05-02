using System;

namespace TiramisuDataGrid.Attributes
{
    public class DependencyAttribute : Attribute
    {
        #region Fields

        private readonly string name;

        #endregion

        #region Constructors

        public DependencyAttribute(string name)
        {
            this.name = name;
        }

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        #endregion
    }
}
