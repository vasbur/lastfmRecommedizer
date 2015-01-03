using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lastfmRecommedizer.UsersDataCashe;

namespace lastfmRecommedizer.Recommendizer
{

    class TrackData
    {
        public TrackInfo track;
        public int count;

    }
    class TrackList
    {
        private List<TrackData> dataset;

        public TrackList()
        {
            dataset = new List<TrackData>();
        }

        public void add(UserData User, TrackInfo track)
        {
            List<TrackData> sublist = dataset.Where(x => x.track.EqualTrack(track)).ToList();
            if (sublist.Count > 0)
                sublist[0].count++;
            else
            {
                TrackData item = new TrackData();
                item.track = track;
                item.count = 1;
                dataset.Add(item);
            }
        }

        public List<TrackData> GetTopTracks(int limit)
        {
            return dataset.OrderByDescending(x => x.count).Take(limit).ToList();
        }

    }
}
