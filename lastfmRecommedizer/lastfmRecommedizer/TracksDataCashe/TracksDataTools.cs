using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lastfmRecommedizer.UsersDataCashe;

namespace lastfmRecommedizer.TracksDataCashe
{
    static class TracksDataTools
    {
        static private List<TrackData> trackDataList;

        
        static public List<UserData> getTopFans(string trackName, string trackMbid, string artistName)
        {
            if (trackDataList == null)
                trackDataList = new List<TrackData>();
            List<TrackData> sel = trackDataList.Where(x => x.isEqual(trackName, trackMbid, artistName)).ToList();

            if (sel.Count > 0)
                return sel[0].GetCurrentFans();
            else
            {
                TrackData item = new TrackData(trackName, trackMbid, artistName);
                trackDataList.Add(item);
                return item.GetCurrentFans();

            }

        }
    }
}
