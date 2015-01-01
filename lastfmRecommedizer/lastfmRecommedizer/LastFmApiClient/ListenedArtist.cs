using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
   public  class ListenedArtist
    {
        [XmlText]
        public string name { get; set; }

        [XmlAttribute(AttributeName = "mbid")]
        public string mbid { get; set; }



    }
}
