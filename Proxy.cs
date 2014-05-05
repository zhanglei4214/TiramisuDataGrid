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

            this.manager.Add(configuration);
        }

        public void Detach(IConfiguration configuraiton)
        {           
            this.manager.Remove(configuraiton);
        }
        
        #endregion
    }
}
