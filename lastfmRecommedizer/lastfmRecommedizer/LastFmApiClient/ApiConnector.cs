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
    class ApiConnector
    {

        public lovedTracksRoot GetApiData(string url)
        {

            HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            Stream ResponseStream = Response.GetResponseStream();
            StreamReader sr = new StreamReader(ResponseStream, Encoding.UTF8);
            string s = sr.ReadToEnd();
                 

            //WebClient WC = new WebClient();
            //string s = WC.DownloadString(url);
            XmlSerializer xml = new XmlSerializer(typeof(lovedTracksRoot));
            lovedTracksRoot res = xml.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(s))) as lovedTracksRoot;

            return res;
        }
    }
}
