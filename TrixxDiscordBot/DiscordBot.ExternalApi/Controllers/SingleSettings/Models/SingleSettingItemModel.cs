namespace DiscordBot.ExternalApi.Controllers.SingleSettings.Models
{
    public class SingleSettingItemModel
    {
        public SingleSettingType Type { get; set; }

        public string Value { get; set; } = string.Empty;
    }
}
