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
            WebClient WC = new WebClient();
            string s = WC.DownloadString(url);
            XmlSerializer xml = new XmlSerializer(typeof(lovedTracksRoot));
            lovedTracksRoot res = xml.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(s))) as lovedTracksRoot;

            return res;
        }
    }
}
