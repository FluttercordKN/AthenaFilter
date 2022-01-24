using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;

namespace AthenaFilter
{
    class ConditionConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(Condition).IsAssignableFrom(objectType);
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;

			var jObject = JObject.Load(reader);

			var target = Create(jObject);

			var jObjectReader = jObject.CreateReader();
			jObjectReader.Culture = reader.Culture;
			jObjectReader.DateParseHandling = reader.DateParseHandling;
			jObjectReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
			jObjectReader.FloatParseHandling = reader.FloatParseHandling;

			serializer.Populate(jObjectReader, target);

			return target;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		private static Condition Create(JObject jObject)
		{
			var kind = jObject["Type"];
			if (kind == null || kind.Type != JTokenType.String)
				throw new ArgumentException("Unable to recognize condition type.");
			var typeValue = kind.ToObject<string>();
            switch (typeValue)
            {
                case "And": return new ConditionAnd();
                case "Or": return new ConditionOr();
                case "Not": return new ConditionNot();
                case "StartsWith": return new ConditionStartsWith();
				case "EndsWith": return new ConditionEndsWith();
				case "Contains": return new ConditionConstains();
				case "Equals": return new ConditionEndsWith();
				case "Regex": return new ConditionRegex();
                default:
					throw new IndexOutOfRangeException(nameof(typeValue));
            }
        }

		private bool FieldExists(string fieldName, JObject jObject)
		{
			return jObject[fieldName] != null;
		}
	}
}
