using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    public class ListenedTracks 
    {
        [XmlElement(ElementName="track")]
        public List<ListenedTrack> listenedTracks { get; set; }

        [XmlAttribute(AttributeName = "page")]
        public string page { get; set; }

        [XmlAttribute(AttributeName = "totalPages")]
        public string totalPages { get; set; }


        public List<UsersDataCashe.TrackInfo> getTrackInfoList()
        {
            List<UsersDataCashe.TrackInfo> result = new List<UsersDataCashe.TrackInfo>();
            foreach (ListenedTrack currentTrack in listenedTracks)
                result.Add(currentTrack.getTrackInfo());
            return result;
        }
    }
}
