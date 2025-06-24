namespace GarminModels
{
    /// <summary>
    /// 天气位置信息
    /// </summary>
    public class WeatherLocation
    {
        public string? UseFixedLocation { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? LocationName { get; set; }
        public string? IsoCountryCode { get; set; }
        public string? PostalCode { get; set; }
    }
}
