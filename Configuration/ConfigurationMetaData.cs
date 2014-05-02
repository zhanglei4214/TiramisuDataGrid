using System.Collections.Generic;

namespace TiramisuDataGrid.Configuration
{
    public class ConfigurationMetaData
    {
        #region Fields

        private bool dependencySolved;

        private Dictionary<string, bool> dependencies;

        #endregion

        #region Constructors

        public ConfigurationMetaData()
        {
            this.dependencies = new Dictionary<string, bool>();

            this.dependencySolved = true;
        }

        #endregion

        #region Properties

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

        public void SolveDependency(string name)
        {
            this.dependencies[name] = true;

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
