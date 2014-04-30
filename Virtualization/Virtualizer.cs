using System;
using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.Control;
using TiramisuDataGrid.DataSource;
using TiramisuDataGrid.EventArgs;

namespace TiramisuDataGrid.Virtualization
{
    public class Virtualizer : IVirtualizer
    {
        #region Fields

        private readonly ChangeObserver observer;

        private readonly TiramisuDataGrid owner;

        #endregion

        #region Constructors

        public Virtualizer(TiramisuDataGrid owner)
        {
            this.owner = owner;

            this.observer = new ChangeObserver();

            this.observer.ArgumentChange += new EventHandler<ObserverEventArgs>(this.ArgumentChangeHandler);
        }

        #endregion

        #region Properties

        public ChangeObserver Observer
        {
            get
            {
                return this.observer;
            }
        }

        #endregion

        #region Public Methods

        public void Update()
        {
            if (this.NeedUpdate() == false)
            {
                return;
            }
        }

        public void Assign(IDataSourceProvider provider, RenderConfiguration configuration)
        {
            if (configuration == null)
            {
                return;
            }

            provider.Bind(this.owner, configuration);

            this.Update();
        }

        #endregion

        #region Private Methods 

        private bool NeedUpdate()
        {
            return false;
        }

        private void ArgumentChangeHandler(object sender, ObserverEventArgs e)
        {
            switch (e.ChangedType)
            {
                case ArgumentType.Both:
                    this.UpdateDataSource(e.DataSource, e.Configuration);
                    this.UpdateConfiguration(e.Configuration);
                    return;
                case ArgumentType.Configuration:
                    this.UpdateConfiguration(e.Configuration);
                    return;
                case ArgumentType.DataSource:
                    this.UpdateDataSource(e.DataSource, e.Configuration);
                    return;
                default:
                    throw new NotSupportedException(e.ChangedType.ToString() + " is not supported.");
            }
        }

        private void UpdateDataSource(IDataSourceProvider dataSource, RenderConfiguration configuration)
        {
            this.Assign(dataSource, configuration);
        }

        private void UpdateConfiguration(RenderConfiguration configuration)
        {
            ControlManager.Verify(this.owner.Children);

            ControlManager.Update(this.owner, configuration.Mode);            
        }

        #endregion
    }
}
