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
            string s="";
            T res=default(T);
            string startTime = System.DateTime.Now.ToString();
            Console.WriteLine(startTime + " start " + url);
            HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
            Request.Timeout = int.MaxValue;
            try
            {
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                Stream ResponseStream = Response.GetResponseStream();
                StreamReader sr = new StreamReader(ResponseStream, Encoding.UTF8);
                s = sr.ReadToEnd();
                Console.WriteLine(System.DateTime.Now.ToString() + " finish " + url);
            }
            catch (Exception e)
            {
                string errorTime = System.DateTime.Now.ToString();
                Console.WriteLine("api error: " + url);
                return GetApiData(url);
            }
  
            XmlSerializer xml = new XmlSerializer(typeof(T));
            try
            {
                res = (T)xml.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(s)));
            }
            catch (Exception e)
            {
                Console.WriteLine("xml error: " + url);
           
            }
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
