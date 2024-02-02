using System.Text.Json.Serialization;

namespace CanAmAPI.Server.Models
{
    public class ZoneDetailContext
    {
        [JsonPropertyName("@version")]
        public string version { get; set; }
    }

    public class ZoneDetailGeometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class ZoneDetailProperties
    {
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

    public class ZoneDetailResponse
    {
        [JsonPropertyName("@context")]
        public ZoneDetailContext context { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public ZoneDetailGeometry geometry { get; set; }
        public ZoneDetailProperties properties { get; set; }
    }
}
