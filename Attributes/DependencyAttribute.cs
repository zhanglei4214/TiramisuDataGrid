using System;
using TiramisuDataGrid.Common;

namespace TiramisuDataGrid.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class DependencyAttribute : Attribute
    {
        #region Fields

        private readonly DependencyName name;

        #endregion

        #region Constructors

        public DependencyAttribute(DependencyName name)
        {
            this.name = name;
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

        #endregion
    }
}
