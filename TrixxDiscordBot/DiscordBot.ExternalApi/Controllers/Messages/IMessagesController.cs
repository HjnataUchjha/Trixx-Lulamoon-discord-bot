namespace DiscordBot.ExternalApi.Controllers.Messages
{
    public interface IMessagesController
    {
        Task SendMessage(ulong channelId, string message);
    }
}
