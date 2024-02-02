using System.Text.Json.Serialization;

namespace CanAmAPI.Server.Models
{
    public class Context
    {
        [JsonPropertyName("@version")]
        public string version { get; set; }
    }

    public class ZoneFeature
    {
        public string id { get; set; }
        public string type { get; set; }
        public Geometry? geometry { get; set; }
        public ZoneProperties properties { get; set; }
    }

    public class ZoneProperties
    {
        [JsonPropertyName("@id")]
        public string idUrl { get; set; }

        [JsonPropertyName("@type")]
        public string zoneType { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime expirationDate { get; set; }
        public string state { get; set; }
        public List<string> cwa { get; set; }
        public List<string> forecastOffices { get; set; }
        public List<string> timeZone { get; set; }
        public List<object> observationStations { get; set; }
        public object radarStation { get; set; }
    }

    public class ZoneResponse
    {
        [JsonPropertyName("@context")]
        public Context context { get; set; }
        public string type { get; set; }
        public List<ZoneFeature> features { get; set; }
    }
}
