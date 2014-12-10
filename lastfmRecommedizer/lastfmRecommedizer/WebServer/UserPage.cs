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
            LastFmApiClient.LovedTracks lt =   LastFmApiClient.ApiTools.GetLovedTracks(username);

            string trackList = "";
            foreach (LastFmApiClient.Track track in lt.tracks) 
                trackList += "<br> " + track.artist.name + " - " + track.name; 
            


            StreamReader st = new StreamReader("C:\\GIT\\GoodProjects\\lastfmRecommedizer\\lastfmRecommedizer\\lastfmRecommedizer\\WebServer\\userPage.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine().Replace("$tracklist$", trackList); 

            return result;
        }
    }
}
