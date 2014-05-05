using System;
using System.ComponentModel;
using System.Globalization;
using TiramisuDataGrid.Configuration.Control;

namespace TiramisuDataGrid.Converters
{
    public class ControlTypeConverter : TypeConverter
    {
        #region Public Methods

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                return null;
            }
            else if (value is IControlConfiguration)
            {
                return value;
            }
            else if (value is String)
            {
                return this.InstantiateControlConfigurationFromString((string)value);
            }
            else
            {
                throw new InvalidCastException("");
            }
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return null;
        }

        #endregion

        #region Private Methods

        private IControlConfiguration InstantiateControlConfigurationFromString(string value)
        {
            value = value.Trim();

            if (value == "Standard")
            {
                return new StandardConfiguration();
            }
            else if (value == "Paging")
            {
                return new PagingConfiguration();
            }
            else if (value.StartsWith("Paging") == true)
            {
                return this.TryInstantiatePagingControlConfiguration(value);
            }
            else
            {
                throw new InvalidCastException("Cannot cast " + value);
            }
        }

        private IControlConfiguration TryInstantiatePagingControlConfiguration(string value)
        {
            string[] arguments = value.Split(new char[] { ',' });

            if (arguments.Length != 2)
            {
                throw new InvalidCastException("Cannot cast " + value);
            }

            string first = arguments[0].Trim();
            if (first != "Paging")
            {
                throw new InvalidCastException("Cannot cast " + value);
            }

            string second = arguments[1].Trim();

            arguments = second.Split(new char[] { '=' });
            first = arguments[0].Trim();
            if (first != "Max")
            {
                throw new InvalidCastException("Cannot cast " + value);
            }

            second = arguments[1].Trim();
            int result;
            if (int.TryParse(second, out result) == false)
            {
                throw new InvalidCastException("Cannot cast " + value);
            }

            return new PagingConfiguration(result);
        }

        #endregion
    }
}
