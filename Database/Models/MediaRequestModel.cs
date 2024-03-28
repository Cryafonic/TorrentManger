using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static TorrentManager.Enums.Enums;

namespace TorrentManager.Database.Models
{
    public class MediaRequestModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string ProvidedName { get; set; } = string.Empty;
        public string TorrentFileName { get; set; } = string.Empty;
        public int MediaFileTypeId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public MediaFileType MediaFileType
        {
            get
            {
                return (MediaFileType)MediaFileTypeId;
            }
        }
        public int MediaRequestStatusId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public MediaRequestStatusType MediaRequestStatusType
        {
            get
            {
                return (MediaRequestStatusType)MediaRequestStatusId;
            }
        }
        public string DownloadableLink { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
