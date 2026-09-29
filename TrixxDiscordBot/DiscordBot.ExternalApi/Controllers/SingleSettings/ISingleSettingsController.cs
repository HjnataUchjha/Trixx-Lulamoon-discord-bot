using DiscordBot.ExternalApi.Controllers.SingleSettings.Models;

namespace DiscordBot.ExternalApi.Controllers.SingleSettings
{
    public interface ISingleSettingsController
    {
        Task<IReadOnlyList<SingleSettingItemModel>> GetSettings();
        Task ReplaceSettings(IReadOnlyList<SingleSettingItemModel> settings);
    }
}
