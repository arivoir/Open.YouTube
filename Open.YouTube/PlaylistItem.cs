using Open.Google;
using System.Runtime.Serialization;

namespace Open.YouTube
{
    [DataContract]
    public class PlaylistItem : GoogleResource
    {
        [DataMember(Name = "snippet", EmitDefaultValue = false)]
        public PlaylistItemSnippet Snippet { get; set; }
        [DataMember(Name = "contentDetails", EmitDefaultValue = false)]
        public PlaylistItemDetails ContentDetails { get; set; }
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public PlaylistItemStatus Status { get; set; }
    }

    [DataContract]
    public class PlaylistItemSnippet
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
        public uint Position { get; set; }

        [DataMember(Name = "resourceId", EmitDefaultValue = false)]
        public VideoResourceId ResourceId { get; set; }
    }

    [DataContract]
    public class PlaylistItemDetails
    {
    }

    [DataContract]
    public class PlaylistItemStatus
    {
    }
}
