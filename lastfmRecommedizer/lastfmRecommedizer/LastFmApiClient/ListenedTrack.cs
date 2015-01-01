using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    public class ListenedTrack
    {
        [XmlElement(ElementName = "name")]
        public string name { get; set; }

        [XmlElement(ElementName = "mbid")]
        public string mbid { get; set; }

        [XmlElement(ElementName = "url")]
        public string url { get; set; }

       
        [XmlElement(ElementName = "artist")]
        public ListenedArtist artist { get; set; }

        public UsersDataCashe.TrackInfo getTrackInfo()
        {
            return new UsersDataCashe.TrackInfo(name, mbid, artist.name, artist.mbid);
        }
  
    }
}
