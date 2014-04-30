using System;

namespace TiramisuDataGrid.Control
{
    public class ControlFactory
    {
        #region Constructors

        private ControlFactory()
        {
        }

        #endregion

        #region Public Methods

        public static IControlInitializer Create(string mode)
        {
            switch (mode)
            {
                case "Standard":
                    return new StandardController();
                case "Paging":
                    return new PagingController();
                case "Benchmark":
                    return new BenchmarkController();
                default:
                    throw new NotSupportedException("mode " + mode.ToString() + " not supported.");
            }
        }

        #endregion
    }
}
