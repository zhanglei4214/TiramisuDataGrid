using System.Collections.Generic;
using System.ComponentModel;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.Virtualization
{
    internal class Proxy
    {
        #region Fields

        private readonly TiramisuDataGrid owner;

        private readonly ConfigurationManager manager;

        #endregion

        #region Constructors

        public Proxy(TiramisuDataGrid owner)
        {
            this.owner = owner;

            this.manager = new ConfigurationManager();
        }

        #endregion        

        #region Properties

        #endregion

        #region Public Methods

        public void Attach(IConfiguration configuration)
        {
            configuration.Owner = this.owner;

            configuration.PropertyChanged += this.ConfigurationPropertyChangedHandler;

            this.manager.Add(configuration);
        }

        public void Detach(IConfiguration configuraiton)
        {
            configuraiton.PropertyChanged -= this.ConfigurationPropertyChangedHandler;

            this.manager.Remove(configuraiton);
        }
        
        #endregion

        #region Private Methods 

        private void ConfigurationPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
        }

        #endregion
    }
}
