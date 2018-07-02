using System.Runtime.Serialization;

namespace Open.YouTube
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name = "error")]
        public Error Error { get; set; }
    }

    [DataContract]
    public class Error
    {
        [DataMember(Name = "errors")]
        public ErrorInfo[] Errors { get; set; }
        [DataMember(Name = "code")]
        public int Code { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
    
    [DataContract]
    public class ErrorInfo
    {
        [DataMember(Name = "domain")]
        public string Domain { get; set; }
        [DataMember(Name = "reason")]
        public string Reason { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
