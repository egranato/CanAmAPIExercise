using System.Text.Json.Serialization;

namespace CanAmAPI.Server.Models
{
    public class Bearing
    {
        public string unitCode { get; set; }
        public int value { get; set; }
    }

    public class Distance
    {
        public string unitCode { get; set; }
        public double value { get; set; }
    }

    public class PointProperties
    {
        [JsonPropertyName("@id")]
        public string id { get; set; }

        [JsonPropertyName("@type")]
        public string type { get; set; }
        public string cwa { get; set; }
        public string forecastOffice { get; set; }
        public string gridId { get; set; }
        public int gridX { get; set; }
        public int gridY { get; set; }
        public string forecast { get; set; }
        public string forecastHourly { get; set; }
        public string forecastGridData { get; set; }
        public string observationStations { get; set; }
        public RelativeLocation relativeLocation { get; set; }
        public string forecastZone { get; set; }
        public string county { get; set; }
        public string fireWeatherZone { get; set; }
        public string timeZone { get; set; }
        public string radarStation { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public Distance distance { get; set; }
        public Bearing bearing { get; set; }
    }

    public class RelativeLocation
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class PointResponse
    {
        [JsonPropertyName("@context")]
        public List<object> context { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public PointProperties properties { get; set; }
    }


}
