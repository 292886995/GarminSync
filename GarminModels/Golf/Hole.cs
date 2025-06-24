namespace GarminModels
{
    /// <summary>
    /// 球洞信息
    /// </summary>
    public class Hole
    {
        public int Number { get; set; }
        public int Strokes { get; set; }
        public int Penalties { get; set; }
        public int HandicapScore { get; set; }
        public int Putts { get; set; }
        public string? FairwayShotOutcome { get; set; }
        public double PinPositionLat { get; set; }
        public double PinPositionLon { get; set; }
    }
}
