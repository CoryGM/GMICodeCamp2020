using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CodeCamp2020.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, string> ToDictionaryString(this object source)
        {
            if (source == null) ThrowExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, string>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);

                if (value != null)
                {
                    if (property.PropertyType == typeof(DateTime) ||
                        property.PropertyType == typeof(DateTime?))
                    {
                        var dateTimeValue = value as DateTime?;

                        if (dateTimeValue.HasValue)
                            dictionary.Add(property.Name, $"{dateTimeValue.Value.ToUniversalTime():o}");
                        else
                            dictionary.Add(property.Name, String.Empty);
                    }
                    else
                    {
                        dictionary.Add(property.Name, $"{value}");
                    }
                }
            }

            return dictionary;
        }

        private static void ThrowExceptionWhenSourceArgumentIsNull()
        {
            throw new NullReferenceException("Unable to convert anonymous object to a dictionary. The source anonymous object is null.");
        }
    }
}
