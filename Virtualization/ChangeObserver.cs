using System;
using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.DataSource;
using TiramisuDataGrid.EventArgs;

namespace TiramisuDataGrid.Virtualization
{
    public class ChangeObserver
    {
        #region Fields

        private RenderConfiguration configuration;

        private IDataSourceProvider source;

        private bool initialized;

        #endregion

        #region Constructors

        public ChangeObserver()
        {
            this.configuration = null;
            this.source = null;

            this.initialized = false;
        }

        #endregion

        #region Events

        public event EventHandler<ObserverEventArgs> ArgumentChange;

        #endregion

        #region Properties

        public RenderConfiguration Configuration
        {
            get
            {
                return this.configuration;
            }

            set
            {
                this.configuration = value;

                if (this.DataSource != null)
                {
                    if (this.initialized == true)
                    {
                        this.OnArgumentChange(ArgumentType.Configuration);
                    }
                    else
                    {
                        this.OnArgumentChange(ArgumentType.Both);
                        this.initialized = true;
                    }
                }
            }
        }

        public IDataSourceProvider DataSource
        {
            get
            {
                return this.source;
            }

            set
            {
                this.source = value;

                if (this.Configuration != null)
                {
                    if (this.initialized == true)
                    {
                        this.OnArgumentChange(ArgumentType.DataSource);
                    }
                    else
                    {
                        this.OnArgumentChange(ArgumentType.Both);
                        this.initialized = true;
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles notifying of a property changed.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        private void OnArgumentChange(ArgumentType type)
        {
            if (this.ArgumentChange != null)
            {
                this.ArgumentChange.Invoke(this, new ObserverEventArgs(type,this.Configuration, this.DataSource));
            }
        }

        #endregion
    }
}
