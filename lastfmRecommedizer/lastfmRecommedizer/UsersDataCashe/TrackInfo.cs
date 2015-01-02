using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.UsersDataCashe
{
    public class TrackInfo
    {
        public string trackName { get; set; }
        public string trackMbid { get; set; }

        public string artistName { get; set; }
        public string artistMbid { get; set; }

        public TrackInfo(string trackName, string trackMbid, string artistName, string artistMbid)
        {
            this.trackName = trackName;
            this.trackMbid = trackMbid;
            this.artistName = artistName;
            this.artistMbid = artistMbid;
        }

        public string getRequestString()
        {
            return "trackname=" + trackName + "&trackmbid=" + trackMbid + "&artistname=" + artistName + "&artistmbid=" + artistMbid;
        }

    }
}
