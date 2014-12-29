using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.WebServer
{
    static class UserPage
    {
        static public string getPage(string username)
        {
            List<UsersDataCashe.TrackInfo> lt = UsersDataCashe.User.getUser(username).lovedTracks;

            string trackList = "";
            foreach (UsersDataCashe.TrackInfo track in lt) 
                trackList += "<br> " + track.artistName + " - " + track.trackName; 
            


            StreamReader st = new StreamReader("C:\\GIT\\GoodProjects\\lastfmRecommedizer\\lastfmRecommedizer\\lastfmRecommedizer\\WebServer\\userPage.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine().Replace("$tracklist$", trackList); 

            return result;
        }
    }
}
