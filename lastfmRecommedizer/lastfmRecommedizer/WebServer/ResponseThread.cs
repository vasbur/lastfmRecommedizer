using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.WebServer
{
    class ResponseThread
    {
        public ResponseThread(HttpListenerContext ListenerContext)
        {
            HttpListenerResponse Response = ListenerContext.Response;

            string rowUrl = ListenerContext.Request.RawUrl;
            String ResponseString = "";
            if (rowUrl.IndexOf("/user") > -1)
            {
                string username = ListenerContext.Request.QueryString["username"];
                ResponseString = UserPage.getPage(username);
            }
            else if (rowUrl.IndexOf("/track") > -1)
            {
                string username = ListenerContext.Request.QueryString["username"];
                string trackName = ListenerContext.Request.QueryString["trackname"];
                string trackMbid = ListenerContext.Request.QueryString["trackmbid"];
                string artistName = ListenerContext.Request.QueryString["artistname"];
                string artistMbid = ListenerContext.Request.QueryString["artistmbid"];
                ResponseString = TrackPage.getPage(username, trackName, trackMbid, artistName, artistMbid);
            }
            else if (rowUrl == "/")
                ResponseString = MainPage.getPage();
            else
                ResponseString = Error404Page.getPage();

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(ResponseString);
            Response.OutputStream.Write(buffer, 0, buffer.Length);
            Response.OutputStream.Close(); 
     
        }
      
    }
}
