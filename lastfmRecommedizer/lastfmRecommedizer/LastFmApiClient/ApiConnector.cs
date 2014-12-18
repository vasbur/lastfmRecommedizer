using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    class ApiConnector<T>
    {
        Task<T> ApiTask; 

        public T GetApiData(string url)
        {

            HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            Stream ResponseStream = Response.GetResponseStream();
            StreamReader sr = new StreamReader(ResponseStream, Encoding.UTF8);
            string s = sr.ReadToEnd();
                 
            XmlSerializer xml = new XmlSerializer(typeof(T));
            T res = (T)xml.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(s)));

            return res;
        }

        private T GetApiDataAsynk(object obj)
        {
            return GetApiData((string)obj);
        }

        public void StartAsync(string url)
        {
            ApiTask = new Task<T>(GetApiDataAsynk, url);
            ApiTask.Start();
        }

        public T GetAsynkResult()
        {
            ApiTask.Wait();
            return ApiTask.Result; 
        }
    }
}
