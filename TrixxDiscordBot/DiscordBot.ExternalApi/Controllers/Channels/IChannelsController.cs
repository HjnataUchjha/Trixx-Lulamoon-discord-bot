using DiscordBot.ExternalApi.Controllers.Channels.Models;

namespace DiscordBot.ExternalApi.Controllers.Channels
{
    public interface IChannelsController
    {
        List<ChannelItemModel> GetChannels();
    }
}
