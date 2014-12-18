using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.LastFmApiClient
{
    interface TrackCollection
    {
        List<Track> tracks { get; set; }
        string page { get; set; }
        string totalPages { get; set; }
    }

    interface TrackCollectionRoot
    {
        LovedTracks TrackCollection { get; set; }
    }

    static class ApiConst
    {
        static public string apiUrl { get { return "http://ws.audioscrobbler.com/2.0/?"; } }
        static public string apiKey { get { return "e2cbaeef2a11b5bdf3152ee8371cc4e0"; } }

    }
     class ApiTools<T>
        where T:TrackCollectionRoot
         {
       

        public List<Track> GetLovedTracks(string username)
        {
            string ApiRequestString = ApiConst.apiUrl + "method=user.getlovedtracks&user=" + username + "&api_key=" + ApiConst.apiKey;

            ApiConnector<T> api = new ApiConnector<T>();
            T LT = api.GetApiData(ApiRequestString);

            List<Track> result = LT.TrackCollection.tracks;

            List<ApiConnector<T>> taskPool = new List<ApiConnector<T>>();
            if (LT.TrackCollection.page != LT.TrackCollection.totalPages)
            {
                for (int i = 2; i <= int.Parse(LT.TrackCollection.totalPages); i++)
                {
                    ApiConnector<T> apiTask = new ApiConnector<T>();
                    apiTask.StartAsync(ApiRequestString + "&page=" + i.ToString());
                    taskPool.Add(apiTask);
                }

                foreach (ApiConnector<T> apiTask in taskPool)
                {
                    T NextPage = apiTask.GetAsynkResult();
                    foreach (Track track in NextPage.TrackCollection.tracks)
                        result.Add(track); 
                }
            }


            return result;

        }
    }
}
