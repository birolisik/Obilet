using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obilet.Application.Models.Sessions
{
    public class SessionResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public DeviceSessionItem DeviceSession { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }

        public class DeviceSessionItem
        {
            [JsonPropertyName("session-id")]
            public string SessionId { get; set; }
            [JsonPropertyName("device-id")]
            public string DeviceId { get; set; }
        }
    }
}
