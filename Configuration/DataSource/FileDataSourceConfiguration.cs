using System;
using System.Collections.Generic;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public abstract class FileDataSourceConfiguration<T> : DataSourceConfigurationBase<T>
    {
        #region Fields

        private readonly string path;

        #endregion

        #region Constructors

        public FileDataSourceConfiguration(string path)
            : base(DataSourceMode.File)
        {
            this.path = path;
        }

        #endregion

        #region Properties

        public string Path
        {
            get
            {
                return this.path;
            }
        }

        #endregion

        #region Public Methods

        public override IEnumerable<T> LoadFromOriginalSource()
        {
            throw new NotImplementedException();
        }

        #endregion        
    }
}
