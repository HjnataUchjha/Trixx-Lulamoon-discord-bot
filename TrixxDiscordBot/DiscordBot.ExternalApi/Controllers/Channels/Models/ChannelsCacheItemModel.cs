using System.Text.Json.Serialization;
using DiscordBot.ExternalApi.Converters;

namespace DiscordBot.ExternalApi.Controllers.Channels.Models
{
    public class ChannelsCacheItemModel
    {
        [JsonConverter(typeof(JsonULongToStringConverter))]
        public ulong ChannelId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
