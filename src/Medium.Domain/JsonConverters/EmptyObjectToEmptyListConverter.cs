using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Medium.Domain.JsonConverters
{
    /// <summary>
    /// Converter necessary since the Rapid API is returning an empty object
    /// for arrays without values. 
    /// This converter converts an empty object to a empty list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class EmptyObjectToEmptyListConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<T> list = new List<T>();

            try
            {
                JArray array = JArray.Load(reader);
                var values = array.Children();
                foreach (JToken obj in array.Children<JToken>())
                {
                    list.Add(obj.Value<T>());
                }
                return list;
            }
            // Exception when the api is returning an {} instead of []
            catch (JsonReaderException)
            {
                JObject.Load(reader);
                return list;
            }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
