using System;

namespace Open.YouTube
{
    public class YouTubeException : Exception
    {
        public YouTubeException(Exception exc)
            : base(exc.Message, exc)
        {
            Error = new Error();
        }

        public YouTubeException(Error error)
            : base(error.Message)
        {
            Error = error;
        }

        public Error Error { get; private set; }
    }
}
