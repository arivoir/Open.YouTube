using Open.Google;
using System.Runtime.Serialization;

namespace Open.YouTube
{
    [DataContract]
    public class Playlist : GoogleResource
    {
        [DataMember(Name = "snippet", EmitDefaultValue = false)]
        public PlaylistSnippet Snippet { get; set; }
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public Status Status { get; set; }
    }

    [DataContract]
    public class Status
    {
        [DataMember(Name = "privacyStatus", EmitDefaultValue = false)]
        public string PrivacyStatus { get; set; }
    }

    [DataContract]
    public class PlaylistSnippet
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
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public string[] Tags { get; set; }
    }

}
