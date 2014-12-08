using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    public class LovedTracks
    {
        [XmlElement(ElementName="track")]
        public List<Track> tracks { get; set; }
    }
}
