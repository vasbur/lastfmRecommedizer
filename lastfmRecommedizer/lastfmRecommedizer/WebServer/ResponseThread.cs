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
                string username = ListenerContext.Request.QueryString["name"];             
                ResponseString = UserPage.getPage(username);
            }
            else
                ResponseString = MainPage.getPage();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(ResponseString);
            Response.OutputStream.Write(buffer, 0, buffer.Length);
            Response.OutputStream.Close(); 
     
        }
      
    }
}
