using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.LastFmApiClient
{
    static class ApiTools
    {
        static private string apiUrl { get { return "http://ws.audioscrobbler.com/2.0/?"; } }
        static private string apiKey { get { return "e2cbaeef2a11b5bdf3152ee8371cc4e0"; } }

        static public LovedTracks GetLovedTracks(string username)
        {

            ApiConnector api = new ApiConnector();
            lovedTracksRoot LT = api.GetApiData(ApiTools.apiUrl+ "method=user.getlovedtracks&user="+username+"&api_key="+ApiTools.apiKey);

            return LT.lovedTracks;

        }
    }
}
