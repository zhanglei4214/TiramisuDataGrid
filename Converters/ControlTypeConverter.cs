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
            else
            {
                throw new InvalidCastException("");
            }
        }

        #endregion
    }
}
