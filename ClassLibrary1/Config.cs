using Rocket.API;

namespace ModerationSystem
{
    public class Config : IRocketPluginConfiguration
    {
        public string Token;
        public string url;
        public string NoReason;
        public string SQLPort;
        public string SQLUser;
        public string SQLHost;
        public string SQLPassword;
        public string SQLDatabase;
        public uint DefaultBanTime;

        public void LoadDefaults()
        {
            Token = "EmberToken";
            url = "https://website.com";
            NoReason = "No reason provided";
            DefaultBanTime = 0;
            SQLHost = "";
            SQLPort = "";
            SQLUser = "";
            SQLPassword = "";
            SQLDatabase = "";
        }
    }
}
