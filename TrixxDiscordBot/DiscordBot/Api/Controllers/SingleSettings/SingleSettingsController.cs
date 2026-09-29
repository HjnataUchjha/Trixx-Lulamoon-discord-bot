using DiscordBot.ExternalApi.Controllers.SingleSettings;
using DiscordBot.ExternalApi.Controllers.SingleSettings.Models;
using DiscordBot.MongoDb;
using DiscordBot.MongoDb.Models.SingleSettings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DiscordBot.Api.Controllers.SingleSettings
{
    public class SingleSettingsController(
        MongoDbContext mongoDbContext) : BaseController, ISingleSettingsController
    {
        private readonly MongoDbContext _mongoDbContext = mongoDbContext;

        [HttpGet]
        public async Task<IReadOnlyList<SingleSettingItemModel>> GetSettings()
        {
            var result = await _mongoDbContext.SingleSettings
                .Find(_ => true)
                .Project(s => new SingleSettingItemModel
                {
                    Type = s.Type,
                    Value = s.Value
                })
                .ToListAsync();

            return result;
        }

        [HttpPost("replace")]
        public async Task ReplaceSettings([FromBody] IReadOnlyList<SingleSettingItemModel> settings)
        {
            await _mongoDbContext.SingleSettings.DeleteManyAsync(_ => true);

            if (settings.Count == 0)
            {
                return;
            }

            var newSettings = settings.Select(s => new SingleSetting
            {
                Type = s.Type,
                Value = s.Value,
            }).ToList();

            await _mongoDbContext.SingleSettings.InsertManyAsync(newSettings);
        }
    }
}
