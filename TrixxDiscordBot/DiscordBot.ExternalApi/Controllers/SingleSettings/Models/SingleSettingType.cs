using System.Runtime.Serialization;

namespace DiscordBot.ExternalApi.Controllers.SingleSettings.Models
{
    public enum SingleSettingType
    {
        [EnumMember(Value = "Модератор (Discord Id) | Роль")]
        ModeratorRole = 100,
    }
}
