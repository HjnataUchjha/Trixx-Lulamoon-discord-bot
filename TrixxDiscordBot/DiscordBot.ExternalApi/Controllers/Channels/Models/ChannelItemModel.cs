using Discord;
using DiscordBot.ExternalApi.Converters;
using System.Text.Json.Serialization;

namespace DiscordBot.ExternalApi.Controllers.Channels.Models
{
    public class ChannelItemModel
    {
        [JsonConverter(typeof(JsonULongToStringConverter))]
        public ulong Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ChannelType Type { get; set; }

        public List<ChannelItemModel> Channels { get; set; } = [];
    }
}
