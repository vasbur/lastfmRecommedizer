﻿using System;
using System.Collections.Generic;
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
            String ResponseString = "HELLO";
            byte[] buffer = System.Text.Encoding.Default.GetBytes(ResponseString);
            Response.OutputStream.Write(buffer, 0, buffer.Length);
            Response.OutputStream.Close(); 
     
        }
      
    }
}
