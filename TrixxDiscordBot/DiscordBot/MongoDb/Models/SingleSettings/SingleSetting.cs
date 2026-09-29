using DiscordBot.ExternalApi.Controllers.SingleSettings.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DiscordBot.MongoDb.Models.SingleSettings
{
    public class SingleSetting
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public SingleSettingType Type { get; set; }

        public string Value { get; set; } = string.Empty;

        public static void Confiigure(MongoDbContext database)
        {
            database.SingleSettings.Indexes.CreateOne(
                new CreateIndexModel<SingleSetting>(
                    Builders<SingleSetting>.IndexKeys.Ascending(c => c.Type),
                    new CreateIndexOptions { Unique = true }
                ));
        }
    }
}
