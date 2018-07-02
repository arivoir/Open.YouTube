using System.Runtime.Serialization;

namespace Open.YouTube
{
    [DataContract]
    public class SearchResult
    {
        [DataMember(Name = "kind", EmitDefaultValue = false)]
        public string Kind { get; set; }
        [DataMember(Name = "etag", EmitDefaultValue = false)]
        public string ETag { get; set; }
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public VideoResourceId Id { get; set; }
        [DataMember(Name = "snippet", EmitDefaultValue = false)]
        public SearchResultSnippet Snippet { get; set; }
    }

    [DataContract]
    public class SearchResultSnippet
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
        [DataMember(Name = "liveBroadcastContent", EmitDefaultValue = false)]
        public string LiveBroadcastContent { get; set; }
    }
}
