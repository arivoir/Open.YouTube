using Open.Google;
using System.Runtime.Serialization;

namespace Open.YouTube
{
    [DataContract]
    public class Video : GoogleResource
    {
        [DataMember(Name = "snippet", EmitDefaultValue=false)]
        public VideoSnippet Snippet { get; set; }
        [DataMember(Name = "contentDetails", EmitDefaultValue = false)]
        public VideoDetails ContentDetails { get; set; }
        [DataMember(Name = "recordingDetails", EmitDefaultValue = false)]
        public RecordingDetails RecordingDetails { get; set; }
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public VideoStatus Status { get; set; }
    }

    [DataContract]
    public class VideoSnippet
    {
        [DataMember(Name = "publishedAt", EmitDefaultValue = false)]
        public string PublishedAt { get; set; }
        [DataMember(Name = "channelId", EmitDefaultValue = false)]
        public string ChannelId { get; set; }
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }
        [DataMember(Name = "thumbnails", EmitDefaultValue = false)]
        public Thumbnails Thumbnails { get; set; }
        [DataMember(Name = "channelTitle", EmitDefaultValue = false)]
        public string ChannelTitle { get; set; }
        [DataMember(Name = "playlistId", EmitDefaultValue = false)]
        public string PlaylistId { get; set; }
        [DataMember(Name = "position", EmitDefaultValue = false)]
        public uint position { get; set; }
        [DataMember(Name = "resourceId", EmitDefaultValue = false)]
        public VideoResourceId ResourceId { get; set; }
        [DataMember(Name = "categoryId", EmitDefaultValue = false)]
        public string CategoryId { get; set; }
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public string[] Tags { get; set; }
    }

    [DataContract]
    public class VideoDetails
    {
        [DataMember(Name = "videoId")]
        public string videoId { get; set; }
        [DataMember(Name = "startAt")]
        public string startAt { get; set; }
        [DataMember(Name = "endAt")]
        public string endAt { get; set; }
        [DataMember(Name = "note")]
        public string note { get; set; }

    }

    [DataContract]
    public class RecordingDetails
    {
        [DataMember(Name = "locationDescription", EmitDefaultValue = false)]
        public string LocationDescription { get; set; }
        [DataMember(Name = "location", EmitDefaultValue = false)]
        public Location Location { get; set; }
        [DataMember(Name = "recordingDate", EmitDefaultValue = false)]
        public string RecordingDate { get; set; }
    }

    [DataContract]
    public class Location
    {
        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        public double Latitude { get; set; }
        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        public double Longitude { get; set; }
        [DataMember(Name = "altitude", EmitDefaultValue = false)]
        public double Altitude { get; set; }
    }

    [DataContract]
    public class VideoStatus
    {
        [DataMember(Name = "uploadStatus", EmitDefaultValue = false)]
        public string UploadStatus { get; set; }
        [DataMember(Name = "failureReason", EmitDefaultValue = false)]
        public string FailureReason { get; set; }
        [DataMember(Name = "rejectionReason", EmitDefaultValue = false)]
        public string RejectionReason { get; set; }
        [DataMember(Name = "privacyStatus", EmitDefaultValue = false)]
        public string PrivacyStatus { get; set; }
        [DataMember(Name = "publishAt", EmitDefaultValue = false)]
        public string PublishAt { get; set; }
        [DataMember(Name = "license", EmitDefaultValue = false)]
        public string License { get; set; }
        [DataMember(Name = "embeddable")]
        public bool Embeddable { get; set; }
        [DataMember(Name = "publicStatsViewable")]
        public bool PublicStatsViewable { get; set; }
    }

    [DataContract]
    public class VideoResourceId
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }
        [DataMember(Name = "videoId")]
        public string VideoId { get; set; }
    }

    [DataContract]
    public class Thumbnails
    {
        [DataMember(Name = "default")]
        public Thumbnail Default { get; set; }
        [DataMember(Name = "medium")]
        public Thumbnail Medium { get; set; }
        [DataMember(Name = "high")]
        public Thumbnail High { get; set; }
        [DataMember(Name = "standard")]
        public Thumbnail Standard { get; set; }
    }

    [DataContract]
    public class Thumbnail
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "width")]
        public uint Width { get; set; }
        [DataMember(Name = "height")]
        public uint Height { get; set; }
    }
}
