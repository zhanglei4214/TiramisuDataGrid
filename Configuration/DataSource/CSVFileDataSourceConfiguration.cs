using System;
using System.Collections.Generic;
using System.IO;

namespace TiramisuDataGrid.Configuration.DataSource
{
    public class CSVFileDataSourceConfiguration<T> : FileDataSourceConfiguration<T>
    {
        #region Fields

        private FileInfo file;

        #endregion

        #region Constructors

        public CSVFileDataSourceConfiguration(string path)
            : base(path)
        {
        }

        #endregion

        #region Public Methods

        public override IEnumerable<T> LoadFromFile(string path, BindingConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
