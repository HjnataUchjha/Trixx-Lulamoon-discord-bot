using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Trixx.Common.Exceptions;
using DiscordBot.ExternalApi.Controllers.Channels.Models;
using DiscordBot.ExternalApi.Controllers.ScheduleEvents.Models;

namespace TrixxDiscordBot.Server.Startup.DiscordBot
{
    public class DiscordBotHttpClient(HttpClient httpClient)
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new JsonStringEnumConverter(),
            },
        };

        private readonly HttpClient _httpClient = httpClient;

        public async Task SendMessageAsync(ulong channelId, string message, CancellationToken cancellationToken = default)
        {
            var url = $"api/discord/Messages/send-message?channelId={channelId}&message={Uri.EscapeDataString(message)}";
            using var response = await _httpClient.PostAsync(url, content: null, cancellationToken);
            await EnsureSuccessAsync(response, cancellationToken);
        }

        public async Task<IReadOnlyList<ChannelItemModel>> GetChannelsAsync(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("api/discord/Channels/channels", cancellationToken);
            await EnsureSuccessAsync(response, cancellationToken);
            return await response.Content.ReadFromJsonAsync<List<ChannelItemModel>>(JsonOptions, cancellationToken) ?? [];
        }

        public async Task ReplaceChannelsCacheAsync(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.PostAsync("api/discord/ChannelsCache/replace", content: null, cancellationToken);
            await EnsureSuccessAsync(response, cancellationToken);
        }

        public async Task<IReadOnlyList<ChannelsCacheItemModel>> GetChannelsCacheAsync(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("api/discord/ChannelsCache", cancellationToken);
            await EnsureSuccessAsync(response, cancellationToken);
            return await response.Content.ReadFromJsonAsync<List<ChannelsCacheItemModel>>(JsonOptions, cancellationToken) ?? [];
        }

        public async Task<IReadOnlyList<VoiceToTextChannelsItemModel>> GetVoiceToTextBindsAsync(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync("api/discord/VoiceToTextChannelBind", cancellationToken);
            await EnsureSuccessAsync(response, cancellationToken);
            return await response.Content.ReadFromJsonAsync<List<VoiceToTextChannelsItemModel>>(JsonOptions, cancellationToken) ?? [];
        }

        public async Task ReplaceVoiceToTextBindsAsync(
            IReadOnlyList<VoiceToTextChannelsUpdateModel> binds,
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.PostAsJsonAsync("api/discord/VoiceToTextChannelBind/replace", binds, JsonOptions, cancellationToken);
            await EnsureSuccessAsync(response, cancellationToken);
        }

        private static async Task EnsureSuccessAsync(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new TrixxException($"DiscordBot API error ({(int)response.StatusCode}): {body}");
        }
    }
}
