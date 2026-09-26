using DiscordBot.ExternalApi.Controllers.ScheduleEvents.Models;

namespace DiscordBot.ExternalApi.Controllers.ScheduleEvents
{
    public interface IVoiceToTextChannelBindController
    {
        Task<IReadOnlyList<VoiceToTextChannelsItemModel>> GetBinds();
        Task ReplaceBinds(IReadOnlyList<VoiceToTextChannelsUpdateModel> binds);
    }
}
