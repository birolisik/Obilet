using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Obilet.Application.Models.Sessions
{
    public class SessionRequest
    {
        public int Type { get; set; }
        public SessionConnection Connection { get; set; }
        public SessionBrowser Browser { get; set; }

        public class SessionBrowser
        {
            public string Name { get; set; }
            public string Version { get; set; }
        }

        public class SessionConnection
        {
            [JsonPropertyName("ip-address")]
            public string IpAddress { get; set; }
            public string Port { get; set; }
        }
    }
}
