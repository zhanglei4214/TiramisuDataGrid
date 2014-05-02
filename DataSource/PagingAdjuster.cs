using System;
using System.Collections;
using TiramisuDataGrid.Configuration;
using TiramisuDataGrid.Configuration.Control;
using TiramisuDataGrid.Configuration.DataSource;

namespace TiramisuDataGrid.DataSource
{
    public class PagingAdjuster : IBindingAdjuster
    {
        #region Constructors

        public PagingAdjuster()
        {
        }

        #endregion

        #region Public Methods

        public IEnumerable Adjust(object original, AdjustConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new NullReferenceException("configuration instance is null.");
            }

            if (original == null)
            {
                return null;
            }

            return this.Adjust(original as IList, configuration);
        }

        #endregion

        #region Private Methods

        private IEnumerable Adjust(IList collection, AdjustConfiguration configuration)
        {
            return collection;
            //if (collection.Count <= renderConfiguration.Max)
            //{
            //    return collection;
            //}

            //int count = 0;
            //IList tmp = new ArrayList();
            //foreach (object item in collection)
            //{
            //    if (count < renderConfiguration.Max)
            //    {
            //        tmp.Add(item);
            //        count++;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //return tmp;
        }

        #endregion
    }
}
