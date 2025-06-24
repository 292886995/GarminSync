namespace GarminModels
{
    /// <summary>
    /// 社交连接列表
    /// </summary>
    public class SocialConnections
    {
        public string? FullName { get; set; }
        public List<SocialConnection>? UserConnections { get; set; }
        public string? Pagination { get; set; }
    }
}
