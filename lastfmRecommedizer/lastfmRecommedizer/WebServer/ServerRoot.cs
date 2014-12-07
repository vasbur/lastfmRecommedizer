using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;


namespace lastfmRecommedizer.WebServer
{
    class ServerRoot
    {
        HttpListener Listener; 

        static void ClientThread(Object StateInfo)
        {
            HttpListenerContext ThreadData = (HttpListenerContext) StateInfo;
            new ResponseThread(ThreadData);
        }

        public ServerRoot()
        {
            Listener = new HttpListener();
            Listener.Prefixes.Add("http://*:"+808+"/");
            Listener.Start(); 

            while (true)
            {
                HttpListenerContext ListenerContext = Listener.GetContext();
                ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), ListenerContext);
            }
        }

        ~ServerRoot()
        {
            if (Listener != null)
            {
                Listener.Stop();
            }
        }
    
    }
}
