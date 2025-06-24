using System.Text.Json.Serialization;

namespace GarminModels
{
    public class Root
    {
        [JsonPropertyName("detailedImportResult")]
        public DetailedImportResult DetailedImportResult { get; set; }
    }

    public class DetailedImportResult
    {
        [JsonPropertyName("uploadId")]
        public long UploadId { get; set; }

        [JsonPropertyName("uploadUuid")]
        public UploadUuid UploadUuid { get; set; }

        [JsonPropertyName("owner")]
        public long Owner { get; set; }

        [JsonPropertyName("fileSize")]
        public long FileSize { get; set; }

        [JsonPropertyName("processingTime")]
        public int ProcessingTime { get; set; }

        [JsonPropertyName("creationDate")]
        public string CreationDate { get; set; }  

        [JsonPropertyName("ipAddress")]
        public string IpAddress { get; set; }  

        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("report")]
        public object Report { get; set; }  

        [JsonPropertyName("successes")]
        public List<object> Successes { get; set; }  

        [JsonPropertyName("failures")]
        public List<object> Failures { get; set; }   
    }

    public class UploadUuid
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }
    }

}
