using Newtonsoft.Json;
using System;

namespace OBiletCase.Model.Models.Request
{
    public class BusJourneyBody
    {
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        public BusJourneyBody()
        {
            DeviceSession = new DeviceSession();
            Data = new Data();
        }
    }

    public class Data
    {
        [JsonProperty("origin-id")]
        public long OriginId { get; set; }

        [JsonProperty("destination-id")]
        public long DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}