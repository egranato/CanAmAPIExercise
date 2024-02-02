namespace CanAmAPI.Server.Models
{
    public class Station
    {
        public string id { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Station(Feature feature)
        {
            id = feature.properties.id;
            name = feature.properties.name;
            longitude = feature.geometry.coordinates[0];
            latitude = feature.geometry.coordinates[1];
        }
    }
}
