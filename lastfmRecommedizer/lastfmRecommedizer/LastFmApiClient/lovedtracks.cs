using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    public class LovedTracks : TrackCollection
    {
        [XmlElement(ElementName="track")]
        public List<Track> tracks { get; set; }

        [XmlAttribute(AttributeName = "page")]
        public string page { get; set; }

        [XmlAttribute(AttributeName = "totalPages")]
        public string totalPages { get; set; }

        public void addTrack(Track track)
        {
            tracks.Add(track);
        }
    }
}
