using Trixx.Common.Exceptions;

namespace TrixxDiscordBot.Server.Startup.DiscordBot
{
    public static class TrixxDiscordBotHttpExtensions
    {
        public static IServiceCollection AddDiscordBotHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var discordBotConfiguration = configuration.ReadRequiredSection<DiscordBotConfiguration>();
            if (string.IsNullOrWhiteSpace(discordBotConfiguration.BaseUrl))
            {
                throw new TrixxException("appsettings.json error, DiscordBot:BaseUrl is empty");
            }

            services.AddSingleton(discordBotConfiguration);
            services.AddHttpClient<DiscordBotHttpClient>(client =>
            {
                client.BaseAddress = new Uri(discordBotConfiguration.BaseUrl.TrimEnd('/') + "/");
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            return services;
        }
    }
}
