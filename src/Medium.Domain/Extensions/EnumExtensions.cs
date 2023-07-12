using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Medium.Domain.Extensions
{
    public static class EnumExtensions
    {
        private static readonly ConcurrentDictionary<Enum, string> _valuesByEnum = new ConcurrentDictionary<Enum, string>();
        private static readonly ConcurrentDictionary<string, Enum> _enumByValue = new ConcurrentDictionary<string, Enum>();

        /// <summary>
        /// Gets the Name property from EnumMemberAttribute. 
        /// If EnumMemberAttribute is not set returns the ToString from the enumValue.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetValue(this Enum enumValue)
        {
            if (_valuesByEnum.TryGetValue(enumValue, out string value))
                return value;

            Type enumType = enumValue.GetType();
            var memberInfo = enumType.GetMembers().SingleOrDefault(x => x.DeclaringType == enumType &&
                                                                        x.Name == enumValue.ToString() &&
                                                                        x.CustomAttributes.Any());
            if (memberInfo != null)
            {
                var enumMemberAttribute = memberInfo.GetCustomAttribute(typeof(EnumMemberAttribute), false);
                if (enumMemberAttribute != null)
                {
                    var valueAttribute = ((EnumMemberAttribute)enumMemberAttribute).Value;
                    _valuesByEnum.TryAdd(enumValue, valueAttribute);
                    return valueAttribute;
                }
            }
            _valuesByEnum.TryAdd(enumValue, enumValue.ToString());
            return enumValue.ToString();
        }

        public static T Parse<T>(this string enumStr) where T : Enum
        {
            if (_enumByValue.TryGetValue(enumStr, out Enum value))
                return (T)value;

            Type enumType = typeof(T);
            var memberInfos = enumType.GetMembers().Where(x => x.DeclaringType == enumType &&
                                                                        x.CustomAttributes.Any());

            foreach (var memberInfo in memberInfos)
            {
                var enumMemberAttribute = memberInfo.GetCustomAttribute(typeof(EnumMemberAttribute), false);
                if (enumMemberAttribute != null)
                {
                    var enumValue = ((EnumMemberAttribute)enumMemberAttribute).Value;
                    if (enumValue == enumStr)
                    {
                        var enumParsed = (T)Enum.Parse(typeof(T), memberInfo.Name);
                        _enumByValue.TryAdd(enumStr, enumParsed);
                        return enumParsed;
                    }
                }
            }
            throw new ArgumentException($"The {enumStr} doesn't not belong to {enumType.Name} enum.");
        }
    }
}
