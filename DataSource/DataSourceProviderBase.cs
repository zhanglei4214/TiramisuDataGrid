using System.Collections;
using System.Collections.ObjectModel;
using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.Control;

namespace TiramisuDataGrid.DataSource
{
    public abstract class DataSourceProviderBase : IDataSourceProvider
    {
        #region Fields

        private readonly SourceType type;

        private IBindingAdjuster adjuster;

        #endregion

        #region Constructors

        public DataSourceProviderBase(SourceType type)
        {
            this.type = type;
        }

        #endregion

        #region Properties

        public SourceType SourceType
        {
            get
            {
                return this.type;
            }
        }

        public object Source
        {
            get
            {
                return this.GetSource();
            }
        }

        public IBindingAdjuster Adjuster
        {
            get
            {
                return this.adjuster;
            }
        }

        public void Bind(object target, RenderConfiguration configuration)
        {
            this.InitializeAdjuster(configuration.Mode);

            this.DoBind(target, this.adjuster.Adjust(this.Source, configuration, new AdjustConfiguration()));
        }

        #endregion

        #region Protected Methods

        protected abstract void DoBind(object target, IEnumerable source);

        protected abstract object GetSource();

        #endregion

        #region Private Methods

        private void InitializeAdjuster(RenderMode mode)
        {
            this.adjuster = BindingAdjusterFactory.Create(mode);
        }

        #endregion
    }
}
