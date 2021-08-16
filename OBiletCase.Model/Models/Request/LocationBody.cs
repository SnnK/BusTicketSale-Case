using Newtonsoft.Json;
using System;

namespace OBiletCase.Model.Models.Request
{
    public class LocationBody
    {
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        public LocationBody()
        {
            DeviceSession = new DeviceSession();
        }
    }
}
