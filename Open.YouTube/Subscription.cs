using Open.Google;
using System.Runtime.Serialization;

namespace Open.YouTube
{
    [DataContract]
    public class Subscription : GoogleResource
    {
        [DataMember(Name = "snippet")]
        public SubscriptionSnippet Snippet { get; set; }
    }

    [DataContract]
    public class SubscriptionSnippet
    {
        [DataMember(Name = "publishedAt")]
        public string PublishedAt { get; set; }
        [DataMember(Name = "channelId")]
        public string ChannelId { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "thumbnails")]
        public Thumbnails Thumbnails { get; set; }
        [DataMember(Name = "resourceId")]
        public SubscriptionResourceId ResourceId { get; set; }
    }

    [DataContract]
    public class SubscriptionResourceId
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }
        [DataMember(Name = "channelId")]
        public string ChannelId { get; set; }
    }
}
