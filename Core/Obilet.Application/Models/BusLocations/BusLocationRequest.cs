using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Application.Models.BusLocations
{
    public class BusLocationRequest
    {
        [JsonPropertyName("device-session")]
        public DeviceSessionItem DeviceSession { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; } = "tr-TR";
        [JsonPropertyName("data")]
        public string SearchData { get; set; }

        public class DeviceSessionItem
        {
            [JsonPropertyName("session-id")]
            public string SessionId { get; set; }
            [JsonPropertyName("device-id")]
            public string DeviceId { get; set; }
        }
    }
}
