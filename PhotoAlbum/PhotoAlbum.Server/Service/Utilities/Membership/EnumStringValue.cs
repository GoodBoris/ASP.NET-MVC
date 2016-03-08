using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Service.Utilities.Membership
{
    //Attribute convert auth type
    public class EnumStringValue : Attribute
    {
        public EnumStringValue(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Enum Parse(Type enumType, string value)
        {
            var enumValues = ToList(enumType);

            return (Enum)Enum.ToObject(enumType, enumValues.First(o => o.Key == value).Value);
        }

        public static string GetStringValue(Enum value)
        {
            var info = value.GetType().GetFields()
                .FirstOrDefault(o => o.Name == value.ToString());
            return GetStringValue(info);
        }

        public static string GetStringValue(FieldInfo value)
        {
            string output = null;

            var attrs = (EnumStringValue[])value.GetCustomAttributes(typeof(EnumStringValue), false);

            if (attrs.Length > 0)
                output = attrs[0].Value;

            return output;
        }

        public static IList<KeyValuePair<string, int>> ToList(Type enumType)
        {
            if (enumType == null)
                throw new ArgumentNullException("type");

            return (from item in enumType.GetFields().Where(o => o.Name != "value__")
                    let value = Convert.ToInt32(Enum.Parse(enumType, item.Name, true))
                    let name = GetStringValue(item) select new KeyValuePair<string, int>(name, value)).ToList();
        }

        public class KeyValuePair<TKey, TValue>
        {
            public KeyValuePair() { }
            public KeyValuePair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }
    }
}