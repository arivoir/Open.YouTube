using Open.Google;
using Open.IO;
using Open.Net.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Open.YouTube
{
    public class YouTubeClient : GoogleClient
    {
        #region ** fields

        public const string Scope = "https://www.googleapis.com/auth/youtube";
        private static readonly string ApiServiceUri = "https://www.googleapis.com/youtube/v3/";
        private static readonly string ApiServiceUploadUri = "https://www.googleapis.com/upload/youtube/v3/videos?uploadType=resumable";

        private string _oauth2Token;

        #endregion

        #region ** initializtion

        public YouTubeClient(string oauth2Token)
        {
            _oauth2Token = oauth2Token;
        }

        #endregion

        #region ** authentication

        public static string GetRequestUrl(string clientId, string callbackUrl)
        {
            return GoogleClient.GetRequestUrl(clientId, Scope, callbackUrl);
        }

        #endregion

        #region ** public methods

        public async Task<GoogleList<Channel>> GetChannelsAsync(string part, bool mine, string fields = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>();
            parameters.Add("part", part);
            if (mine)
                parameters.Add("mine", "true");
            var response = await client.GetAsync(BuildUri(ApiServiceUri + "channels", fields: fields, parameters: parameters), cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<GoogleList<Channel>>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Channel> GetChannelAsync(string part, string channelId)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>();
            parameters.Add("part", part);
            parameters.Add("id", channelId);
            var response = await client.GetAsync(BuildUri(ApiServiceUri + "channels", parameters: parameters));
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadJsonAsync<GoogleList<Channel>>()).Items.FirstOrDefault();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<GoogleList<Playlist>> GetPlaylistsAsync(string part, bool mine, string fields = null, string pageToken = null, int? maxResults = null, string orderby = null)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>();
            parameters.Add("part", part);
            if (mine)
                parameters.Add("mine", "true");
            var response = await client.GetAsync(BuildUri(ApiServiceUri + "playlists", fields: fields, pageToken: pageToken, maxResults: maxResults, parameters: parameters));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<GoogleList<Playlist>>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<GoogleList<PlaylistItem>> GetPlaylistItemsAsync(string playlistId, string part, string fields = null, string pageToken = null, int? maxResults = null, string orderby = null)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "part", part },
                { "playlistId", playlistId },
            };
            var uri = GoogleClient.BuildUri(ApiServiceUri + "playlistItems", fields: fields, pageToken: pageToken, maxResults: maxResults, orderby: orderby, parameters: parameters);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<GoogleList<PlaylistItem>>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<GoogleList<Subscription>> GetSubscriptionsAsync(string part, bool mine, string fields = null, string pageToken = null, int? maxResults = null, string orderby = null)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>();
            parameters.Add("part", part);
            if (mine)
                parameters.Add("mine", "true");
            var uri = GoogleClient.BuildUri(ApiServiceUri + "subscriptions", fields: fields, pageToken: pageToken, maxResults: maxResults, orderby: orderby, parameters: parameters);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<GoogleList<Subscription>>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Video> GetVideoAsync(string videoId, string part)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>();
            parameters.Add("part", part);
            parameters.Add("id", videoId);
            var uri = GoogleClient.BuildUri(ApiServiceUri + "videos", parameters: parameters);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadJsonAsync<GoogleList<Video>>()).Items.FirstOrDefault();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Playlist> GetPlaylistAsync(string part, string playlistId)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>();
            parameters.Add("part", part);
            parameters.Add("id", playlistId);
            var uri = GoogleClient.BuildUri(ApiServiceUri + "playlists", parameters: parameters);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadJsonAsync<GoogleList<Playlist>>()).Items.FirstOrDefault();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Playlist> InsertPlaylistAsync(string part, string title, string description, string privacyStatus, string[] tags)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "part", part },
            };
            var uri = BuildUri(ApiServiceUri + "playlists", parameters: parameters);
            var playlist = new Playlist();
            playlist.Snippet = new PlaylistSnippet();
            playlist.Snippet.Title = title;
            if (!string.IsNullOrEmpty(description))
                playlist.Snippet.Description = description;
            playlist.Snippet.Tags = tags;
            playlist.Status = new Status();
            playlist.Status.PrivacyStatus = privacyStatus;
            var textContent = new StringContent(playlist.SerializeJson());
            textContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(uri, textContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Playlist>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<string> InsertVideo(string part, string title, string description, string categoryId, string[] tags, string license, bool embeddable, string privacyStatus, bool publicStatsViewable, string publishAt, string locationDescription, double latitude, double longitude, string recordingDate)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "part", part },
            };
            var uri = BuildUri(ApiServiceUploadUri, parameters: parameters);
            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = title;
            video.Snippet.Description = description;
            video.Snippet.CategoryId = categoryId;
            video.Snippet.Tags = tags;
            video.Status = new VideoStatus();
            video.Status.Embeddable = embeddable;
            video.Status.License = license;
            video.Status.PrivacyStatus = privacyStatus;
            video.Status.PublicStatsViewable = publicStatsViewable;
            video.Status.PublishAt = publishAt;
            if (!double.IsNaN(latitude) && !double.IsNaN(longitude))
            {
                video.RecordingDetails = new RecordingDetails();
                video.RecordingDetails.LocationDescription = locationDescription;
                video.RecordingDetails.RecordingDate = recordingDate;
                video.RecordingDetails.Location = new Location();
                video.RecordingDetails.Location.Latitude = latitude;
                video.RecordingDetails.Location.Longitude = longitude;
            }
            var textContent = new StringContent(video.SerializeJson());
            textContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(uri, textContent);
            if (response.IsSuccessStatusCode)
            {
                return response.Headers.Location.AbsoluteUri;
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Video> UploadVideo(string contentType, Stream fileStream, string url, IProgress<StreamProgress> progress, CancellationToken cancellationToken)
        {
            var client = CreateHttpClient();
            var content = new StreamedContent(fileStream, progress, cancellationToken);
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            var response = await client.PostAsync(new Uri(url), content, cancellationToken);//.AsTask(cancellationToken, progress);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Video>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task DeleteVideoAsync(string videoId)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "id", videoId },
            };
            var uri = BuildUri(ApiServiceUri + "videos", parameters: parameters);
            var response = await client.DeleteAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task DeletePlaylistAsync(string playlistId)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "id", playlistId },
            };
            var uri = BuildUri(ApiServiceUri + "playlists", parameters: parameters);
            var response = await client.DeleteAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Playlist> UpdatePlaylistAsync(string playlistId, string part, string title, string summary, string[] tags, string privacyStatus)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "part", part },
            };
            var uri = BuildUri(ApiServiceUri + "playlists", parameters: parameters);
            var playlist = new Playlist();
            playlist.Id = playlistId;
            playlist.Snippet = new PlaylistSnippet();
            playlist.Snippet.Title = title;
            if (!string.IsNullOrEmpty(summary))
                playlist.Snippet.Description = summary;
            playlist.Snippet.Tags = tags;
            playlist.Status = new Status();
            playlist.Status.PrivacyStatus = privacyStatus;
            var textContent = new StringContent(playlist.SerializeJson());
            textContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(uri, textContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Playlist>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<Video> UpdateVideoAsync(string part, string videoId, string title, string description, string categoryId, string[] tags, string license, bool embeddable, string privacyStatus, bool publicStatsViewable, string publishAt, string locationDescription, double latitude, double longitude, string recordingDate)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "part", part },
            };
            var uri = BuildUri(ApiServiceUri + "videos", parameters: parameters);
            var video = new Video();
            video.Id = videoId;
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = title;
            video.Snippet.Description = description;
            video.Snippet.CategoryId = categoryId;
            video.Snippet.Tags = tags;
            video.Status = new VideoStatus();
            video.Status.Embeddable = embeddable;
            video.Status.License = license;
            video.Status.PrivacyStatus = privacyStatus;
            video.Status.PublicStatsViewable = publicStatsViewable;
            video.Status.PublishAt = publishAt;
            if (!double.IsNaN(latitude) && !double.IsNaN(longitude))
            {
                video.RecordingDetails = new RecordingDetails();
                video.RecordingDetails.LocationDescription = locationDescription;
                video.RecordingDetails.RecordingDate = recordingDate;
                video.RecordingDetails.Location = new Location();
                video.RecordingDetails.Location.Latitude = latitude;
                video.RecordingDetails.Location.Longitude = longitude;
            }
            var videoString = video.SerializeJson();
            var textContent = new StringContent(videoString);
            textContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(uri, textContent);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<Video>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        public async Task<GoogleList<SearchResult>> SearchAsync(string part, string type, bool? forMine, string q, string fields)
        {
            var client = CreateHttpClient();
            var parameters = new Dictionary<string, string>();
            parameters.Add("part", part);
            parameters.Add("type", type);
            if (forMine.HasValue)
                parameters.Add("forMine", forMine.Value.ToString());
            var response = await client.GetAsync(BuildUri(ApiServiceUri + "search", fields: fields, q: q, parameters: parameters));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadJsonAsync<GoogleList<SearchResult>>();
            }
            else
            {
                throw await ProcessException(response.Content);
            }
        }

        #endregion

        #region ** private stuff

        private HttpClient CreateHttpClient()
        {
            //var rootFilter = new HttpBaseProtocolFilter();
            //rootFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            //rootFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            var client = new HttpClient(/*rootFilter*/);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _oauth2Token);
            //client.DefaultRequestHeaders.CacheControl.Add(new HttpNameValueHeaderValue("no-cache"));
            client.Timeout = Timeout.InfiniteTimeSpan;
            return client;
        }

        private async Task<Exception> ProcessException(HttpContent content)
        {
            var error = await content.ReadJsonAsync<ErrorResponse>();
            return new YouTubeException(error.Error);
        }

        #endregion
    }
}
