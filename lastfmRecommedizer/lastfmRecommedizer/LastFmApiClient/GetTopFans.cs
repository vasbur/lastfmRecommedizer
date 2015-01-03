using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.LastFmApiClient
{
    static class TopFans
    {
        static public List<string> GetTopFans(string trackname, string trackmbid, string artistname)
        {

            string ApiRequestString;
            if (trackmbid.Length>0)
                ApiRequestString = ApiConst.apiUrl + "method=track.gettopfans&mbid="+trackmbid+"&api_key=" + ApiConst.apiKey;
            else
                ApiRequestString = ApiConst.apiUrl + "method=track.gettopfans&artist=" + artistname+"&track="+trackname +"&api_key=" + ApiConst.apiKey;

    

            ApiConnector<TopFansRoot> api = new ApiConnector<TopFansRoot>();
            TopFansRoot TopFans = api.GetApiData(ApiRequestString);

            List<string> result = new List<string>();
            foreach (User us in TopFans.Userlist.Users)
                result.Add(us.name);

            return result;

        }
    }
}
