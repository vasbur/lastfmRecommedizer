using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    [XmlRoot(ElementName="lfm")]
    public class lovedTracksRoot
    {
        [XmlElement(ElementName = "lovedtracks")]
        public LovedTracks lovedTracks { get; set; }
    }
}
