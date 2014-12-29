using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    [XmlRoot(ElementName = "lfm")]
    public class bannedTracksRoot : ITrackCollectionRoot
    {
        [XmlElement(ElementName = "bannedtracks")]
        public LovedTracks TrackCollection { get; set; }

        public List<UsersDataCashe.TrackInfo> getTrackInfoList()
        {
            return TrackCollection.getTrackInfoList();
        }

        public string currentPage()
        {
            return TrackCollection.page;
        }
        public string totalPages()
        {
            return TrackCollection.totalPages;
        }
  
    }
}
