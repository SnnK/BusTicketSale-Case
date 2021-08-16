using Newtonsoft.Json;

namespace OBiletCase.Model.Models.Request
{
    public class SessionBody
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("browser")]
        public Browser Browser { get; set; }

        public SessionBody()
        {
            Connection = new Connection();
            Browser = new Browser();
        }
    }

    public class Browser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }
    }
}