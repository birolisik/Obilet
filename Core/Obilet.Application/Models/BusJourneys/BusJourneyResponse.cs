using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obilet.Application.Models.BusJourneys
{
    public class BusJourneyResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public List<JourneyDataItem> JourneyData { get; set; }

        public class JourneyDataItem
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("journey")]
            public JourneyItem Journey { get; set; }

            [JsonPropertyName("origin-location-id")]
            public int OriginLocationId { get; set; }
            [JsonPropertyName("destination-location-id")]
            public int DestinationLocationid { get; set; }
            [JsonPropertyName("origin-location")]
            public string OriginLocation { get; set; }
            [JsonPropertyName("destination-location")]
            public string DestinationLocation { get; set; }

        }

        public class JourneyItem
        {
            [JsonPropertyName("origin")]
            public string Origin { get; set; }
            [JsonPropertyName("destination")]
            public string Destination { get; set; }
            [JsonPropertyName("departure")]
            public string Departure { get; set; }
            [JsonPropertyName("arrival")]
            public string Arrival { get; set; }
            [JsonPropertyName("currency")]
            public string Currency { get; set; }

            [JsonPropertyName("internet-price")]
            public double internetprice { get; set; }
        }
    }
}
