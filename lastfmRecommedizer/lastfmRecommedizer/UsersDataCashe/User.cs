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
                 List<TrackInfo> LT = ApiTool.GetLovedTracks(username);
                 UserData result = new UserData(username, LT);
                 userlist.Add(result);
                 return result; 
             }

        }

    }
}
