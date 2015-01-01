using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.UsersDataCashe
{
    static class User
    {
        static private List<UserData> userlist;

    
        static public UserData getUser(string username)
        {
            if (userlist == null)
                userlist = new List<UserData>(); 

             List<UserData> f =  userlist.Where(t => t.username == username).Take(1).ToList();
             if (f.Count > 0)
                 return f[0];
             else
             {
                 LastFmApiClient.ApiTools<LastFmApiClient.lovedTracksRoot> ApiTool = new LastFmApiClient.ApiTools<LastFmApiClient.lovedTracksRoot>();
                 ApiTool.StartAsync(username, "getlovedtracks");

                 LastFmApiClient.ApiTools<LastFmApiClient.bannedTracksRoot> ApiTool2 = new LastFmApiClient.ApiTools<LastFmApiClient.bannedTracksRoot>();
                 ApiTool2.StartAsync(username, "getbannedtracks");

                 LastFmApiClient.ApiTools<LastFmApiClient.ListenedTracksRoot> ListenedTracksTool = new LastFmApiClient.ApiTools<LastFmApiClient.ListenedTracksRoot>();
                 ListenedTracksTool.StartAsync(username, "getrecenttracks");

                 UserData result = new UserData(username, ApiTool.GetAsyncResult(), ApiTool2.GetAsyncResult(), ListenedTracksTool.GetAsyncResult());
                 userlist.Add(result);
                 return result; 
             }

        }

    }
}
