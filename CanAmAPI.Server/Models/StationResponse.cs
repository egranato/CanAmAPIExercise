﻿using System.Text.Json.Serialization;

namespace CanAmAPI.Server.Models
{
    public class Elevation
    {
        public string unitCode { get; set; }
        public double value { get; set; }
    }

    public class Feature
    {
        public string id { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Pagination
    {
        public string next { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("@id")]
        public string id { get; set; }

        [JsonPropertyName("@type")]
        public string type { get; set; }
        public Elevation elevation { get; set; }
        public string stationIdentifier { get; set; }
        public string name { get; set; }
        public string timeZone { get; set; }
        public string forecast { get; set; }
        public string county { get; set; }
        public string fireWeatherZone { get; set; }
    }

    public class StationResponse
    {
        [JsonPropertyName("@context")]
        public List<object> context { get; set; }
        public string type { get; set; }
        public List<Feature> features { get; set; }
        public List<string> observationStations { get; set; }
        public Pagination pagination { get; set; }
    }
}
