using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.WebServer
{
    static class TrackPage
    {
        static public string getPage(string username, string trackName, string trackMbid, string artistName, string artistMbid)
        {
            List<UsersDataCashe.UserData> userList = TracksDataCashe.TracksDataTools.getTopFans(trackName, trackMbid, artistMbid);
            List<Recommendizer.TrackData> resultList = Recommendizer.RecomTools.GetRecomendTracks(null, userList);

            string trackList = "обработано треков: "+userList.Count.ToString();
            foreach ( Recommendizer.TrackData trackData in resultList)
                trackList += "<br> " + trackData.track.artistName + " - <a href=\""+trackData.track.trackUrl+"\">" + trackData.track.trackName + "</a> - "+trackData.count.ToString(); 
            
            StreamReader st = new StreamReader("C:\\GIT\\GoodProjects\\lastfmRecommedizer\\lastfmRecommedizer\\lastfmRecommedizer\\WebServer\\TrackPage.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine().Replace("$tracklist$", trackList); 

            return result;
        }
    }
}
