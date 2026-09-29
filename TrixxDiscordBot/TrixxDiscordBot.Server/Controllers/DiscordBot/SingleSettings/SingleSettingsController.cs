using DiscordBot.ExternalApi.Controllers.SingleSettings.Models;
using Microsoft.AspNetCore.Mvc;
using Trixx.Database.Enums;
using TrixxDiscordBot.Server.Startup.DiscordBot;

namespace TrixxDiscordBot.Server.Controllers.DiscordBot.SingleSettings
{
    public class SingleSettingsController(DiscordBotHttpClient discordBotHttpClient) : ApiController
    {
        private readonly DiscordBotHttpClient _discordBotHttpClient = discordBotHttpClient;

        [HttpGet]
        [TrixxClaimsAuthorize(Permission.DiscordBotSingleSettings_Read)]
        public async Task<IReadOnlyList<SingleSettingItemModel>> GetSettingsAsync()
        {
            return await _discordBotHttpClient.GetSettingsAsync();
        }

        [HttpPost("replace")]
        [TrixxClaimsAuthorize(Permission.DiscordBotSingleSettings_Edit)]
        public async Task ReplaceSettingsAsync(IReadOnlyList<SingleSettingItemModel> settings)
        {
            await _discordBotHttpClient.ReplaceSettingsAsync(settings);
        }
    }
}
