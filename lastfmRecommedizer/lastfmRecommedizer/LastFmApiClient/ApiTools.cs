using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.LastFmApiClient
{
   
   interface ITrackCollectionRoot
    {
       List<UsersDataCashe.TrackInfo> getTrackInfoList();
       string currentPage();
       string totalPages();
   }

    static class ApiConst
    {
        static public string apiUrl { get { return "http://ws.audioscrobbler.com/2.0/?"; } }
        static public string apiKey { get { return "e2cbaeef2a11b5bdf3152ee8371cc4e0"; } }

    }
     class ApiTools<T>
        where T : ITrackCollectionRoot
         {
       

        public List<UsersDataCashe.TrackInfo> GetTracks(string username, string apiMethod)
        {
            string ApiRequestString = ApiConst.apiUrl + "method=user."+apiMethod+"&user=" + username + "&api_key=" + ApiConst.apiKey;

            ApiConnector<T> api = new ApiConnector<T>();
            T LT = api.GetApiData(ApiRequestString);

            List<UsersDataCashe.TrackInfo> result = LT.getTrackInfoList();

            List<ApiConnector<T>> taskPool = new List<ApiConnector<T>>();
            if (LT.currentPage() != LT.totalPages())
            {
                for (int i = 2; i <= int.Parse(LT.totalPages()); i++)
                {
                    ApiConnector<T> apiTask = new ApiConnector<T>();
                    apiTask.StartAsync(ApiRequestString + "&page=" + i.ToString());
                    taskPool.Add(apiTask);
                }

                foreach (ApiConnector<T> apiTask in taskPool)
                {
                    T NextPage = apiTask.GetAsynkResult();
                    foreach (UsersDataCashe.TrackInfo track in NextPage.getTrackInfoList())
                        result.Add(track); 
                }
            }


            return result;

        }
    }
}
