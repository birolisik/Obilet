using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obilet.Application.Models.BusJourneys
{
    public class BusJourneyRequest
    {
        [JsonPropertyName("device-session")]
        public DeviceSessionItem DeviceSession { get; set; }

        [JsonPropertyName("data")]
        public JourneyDataItem JourneyData { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; } = "tr-TR";


        public class DeviceSessionItem
        {
            [JsonPropertyName("session-id")]
            public string SessionId { get; set; }

            [JsonPropertyName("device-id")]
            public string DeviceId { get; set; }
        }

        public class JourneyDataItem
        {
            [JsonPropertyName("origin-id")]
            public int OriginId { get; set; }

            [JsonPropertyName("destination-id")]
            public int DestinationId { get; set; }

            [JsonPropertyName("departure-date")]
            public string DepartureDate { get; set; }

        }
    }
}
