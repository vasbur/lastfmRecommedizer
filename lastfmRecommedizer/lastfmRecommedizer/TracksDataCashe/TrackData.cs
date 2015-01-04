using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lastfmRecommedizer.UsersDataCashe;

namespace lastfmRecommedizer.TracksDataCashe
{
    class TrackData
    {
        private string  trackName;
        private string trackMbid;
        private string artistName;

        private List<string> topFansNames;
        private List<UserData> topFansData;
        private List<UserRequest> topFansCurrentRequests;

        private void pushRequestTasks()
        {
            int i = 0;
            while (i < topFansCurrentRequests.Count)
                if (topFansCurrentRequests[i].IsCompleted())
                {
                    topFansData.Add(topFansCurrentRequests[i].GetResult());
                    topFansCurrentRequests.Remove(topFansCurrentRequests[i]);
                }
                else
                    i++;

            while ((topFansNames.Count>0) && (topFansCurrentRequests.Count < 5))
            {
                UserRequest request = new UsersDataCashe.UserRequest(topFansNames[0]);
                request.Start();
                topFansCurrentRequests.Add(request);
                topFansNames.Remove(topFansNames[0]);

            }

        }
        public TrackData(string trackName, string trackMbid, string artistName)
        {
            this.trackName = trackName;
            this.trackMbid = trackMbid;
            this.artistName = artistName;

            topFansNames = LastFmApiClient.TopFans.GetTopFans(trackName, trackMbid, artistName);
            topFansData = new List<UserData>();
            topFansCurrentRequests = new List<UserRequest>();

            pushRequestTasks();
        }

        public bool isEqual(string trackName, string trackMbid, string artistName)
        {
            if (this.trackMbid != "")
                return (this.trackMbid == trackMbid);
            else
                return ((this.trackName == trackName) && (this.artistName == artistName));
        }

        public List<UserData> GetCurrentFans()
        {
            pushRequestTasks();
            while (topFansData.Count < 5)
                pushRequestTasks();

            return topFansData; 
        }
    }
}
