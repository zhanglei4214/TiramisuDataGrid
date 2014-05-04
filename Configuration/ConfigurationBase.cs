using System;
using System.ComponentModel;
using System.Windows.Controls;
using TiramisuDataGrid.EventArgs;

namespace TiramisuDataGrid.Configuration
{
    public class ConfigurationBase : IConfiguration
    {
        #region Constructors

        public ConfigurationBase(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Events

        public event EventHandler<ConfigurationChangedEventArgs> Changed;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public string Name { get; private set; }

        public DockPanel Owner { get; set; }

        #endregion

        #region Public Methods

        public virtual void Attach()
        {
            if (this.Changed != null)
            {
                this.Changed(this, new ConfigurationChangedEventArgs(this, ConfigurationChangeAction.Add));
            }
        }

        public virtual void Detach()
        {
            if (this.Changed != null)
            {
                this.Changed(this, new ConfigurationChangedEventArgs(this, ConfigurationChangeAction.Remove));
            }
        }

        public virtual void SolveDependency(IConfiguration dependency)
        {
        }

        #endregion

        #region Protected Methods        

        /// <summary>
        /// Handles notifying of a property changed.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
