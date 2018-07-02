using Open.Google;
using System.Runtime.Serialization;

namespace Open.YouTube
{
    [DataContract]
    public class Channel : GoogleResource
    {
        [DataMember(Name = "contentDetails", EmitDefaultValue = false)]
        public ContentDetails ContentDetails { get; set; }
        [DataMember(Name = "googlePlusUserId", EmitDefaultValue = false)]
        public string GooglePlusUserId { get; set; }
    }

    [DataContract]
    public class ContentDetails
    {
        [DataMember(Name = "relatedPlaylists", EmitDefaultValue = false)]
        public RelatedPlaylists RelatedPlaylists { get; set; }
    }

    [DataContract]
    public class RelatedPlaylists
    {
        [DataMember(Name = "likes", EmitDefaultValue = false)]
        public string Likes { get; set; }
        [DataMember(Name = "favorites", EmitDefaultValue = false)]
        public string Favorites { get; set; }
        [DataMember(Name = "uploads", EmitDefaultValue = false)]
        public string Uploads { get; set; }
        [DataMember(Name = "watchHistory", EmitDefaultValue = false)]
        public string WatchHistory { get; set; }
        [DataMember(Name = "watchLater", EmitDefaultValue = false)]
        public string WatchLater { get; set; }
    }
}
