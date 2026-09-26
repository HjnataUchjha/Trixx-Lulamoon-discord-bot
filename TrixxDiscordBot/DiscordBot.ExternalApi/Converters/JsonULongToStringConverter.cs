using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscordBot.ExternalApi.Converters
{
    public class JsonULongToStringConverter : JsonConverter<ulong>
    {
        public override ulong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => ulong.Parse(reader.GetString()!);

        public override void Write(Utf8JsonWriter writer, ulong value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString());
    }
}
