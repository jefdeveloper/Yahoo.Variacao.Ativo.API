using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public class TimestampParaDateTimeConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTimeOffset dateTimeOffset = new DateTimeOffset((DateTime)value);
            writer.WriteRawValue(dateTimeOffset.ToUnixTimeSeconds().ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds((long)reader.Value);
            return dateTimeOffset.DateTime;
        }
    }
}
