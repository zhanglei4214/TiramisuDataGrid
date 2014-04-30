using System;
using System.Collections;
using TiramisuDataGrid.Configuration;

namespace TiramisuDataGrid.Control
{
    public class PagingAdjuster : IBindingAdjuster
    {
        #region Constructors

        public PagingAdjuster()
        {
        }

        #endregion

        #region Public Methods

        public IEnumerable Adjust(object original, RenderConfiguration renderConfiguration, AdjustConfiguration adjustConfiguration)
        {
            if (renderConfiguration == null)
            {
                throw new NullReferenceException("PagingRenderConfiguration instance is null.");
            }

            if (original == null)
            {
                return null;
            }

            return this.Adjust(original as IList, renderConfiguration.Paging, adjustConfiguration);
        }

        #endregion

        #region Private Methods

        private IEnumerable Adjust(IList collection, PagingRenderConfiguration renderConfiguration, AdjustConfiguration adjustConfiguration)
        {
            if (collection.Count <= renderConfiguration.Max)
            {
                return collection;
            }

            int count = 0;
            IList tmp = new ArrayList();
            foreach (object item in collection)
            {
                if (count < renderConfiguration.Max)
                {
                    tmp.Add(item);
                    count++;
                }
                else
                {
                    break;
                }
            }

            return tmp;
        }

        #endregion
    }
}
