namespace TrixxDiscordBot.Server.Startup.DiscordBot
{
    public class DiscordBotConfiguration : IConfigurationSection
    {
        public static string ConfigName => "DiscordBot";

        public string BaseUrl { get; set; } = string.Empty;
    }
}
