using System.Collections.Generic;

namespace TiramisuDataGrid.Configuration
{
    public class ConfigurationMetaData
    {
        #region Fields

        private readonly IConfiguration owner;

        private bool dependencySolved;

        private Dictionary<string, bool> dependencies;

        #endregion

        #region Constructors

        public ConfigurationMetaData(IConfiguration owner)
        {
            this.owner = owner;

            this.dependencies = new Dictionary<string, bool>();

            this.dependencySolved = true;
        }

        #endregion

        #region Properties

        public IConfiguration Owner
        {
            get
            {
                return this.owner;
            }
        }

        public bool DependencySolved
        {
            get
            {
                return this.dependencySolved;
            }
        }

        #endregion

        #region Public Methods

        public void AddDependency(string name)
        {
            this.dependencies[name] = false;

            this.dependencySolved = false;
        }

        public void SolveDependency(IConfiguration configuration)
        {
            this.dependencies[configuration.Name] = true;

            this.Owner.SolveDependency(configuration);

            foreach (bool result in this.dependencies.Values)
            {
                if (result == false)
                {
                    this.dependencySolved = false;
                    return;
                }
            }

            this.dependencySolved = true;
        }

        #endregion
    }
}
