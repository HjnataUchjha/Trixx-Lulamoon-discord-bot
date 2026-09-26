using DiscordBot.ExternalApi.Controllers.Channels.Models;

namespace DiscordBot.ExternalApi.Controllers.Channels
{
    public interface IChannelsCacheController
    {
        Task ReplaceChannels();
        Task<IReadOnlyList<ChannelsCacheItemModel>> GetChannels();
    }
}
