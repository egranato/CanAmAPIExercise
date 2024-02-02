namespace CanAmAPI.Server.Models
{
    public class Zone
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public Zone(ZoneFeature feature)
        {
            id = feature.properties.id;
            name = feature.properties.name;
            type = feature.properties.type;
        }
    }
}
