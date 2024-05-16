namespace VY.Business.Layer.Auth.DTO.MapBox
{
    public class MapboxGetDTO
    {
        public List<MapBoxDTOData> routes { get; set; } = new List<MapBoxDTOData>();
    }
    public class MapBoxDTOData
    {
        public double distance { get; set; }
    }
}
