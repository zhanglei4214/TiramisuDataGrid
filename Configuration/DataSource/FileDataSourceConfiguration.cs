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

        #region Public Methods

        public abstract IEnumerable<T> LoadFromFile(string path, BindingConfiguration configuration);

        public override IEnumerable<T> LoadFromOriginalSource(BindingConfiguration configuration)
        {
            return this.LoadFromFile(this.path, configuration);
        }

        #endregion        
    }
}
