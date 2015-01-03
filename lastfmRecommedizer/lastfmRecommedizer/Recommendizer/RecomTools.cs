using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lastfmRecommedizer.UsersDataCashe;

namespace lastfmRecommedizer.Recommendizer
{
    static class RecomTools
    {

        static public List<TrackData> GetRecomendTracks(UserData CurrentUser, List<UserData> UserList)
        {
            TrackList tracklist = new TrackList();
            foreach (UserData user in UserList)
            {
                var keys = new HashSet<string>();
                List<TrackInfo> tracks = user.listenedTracks.Where(x => keys.Add(x.getRequestString()) == true).ToList();
                foreach (TrackInfo track in tracks)
                    tracklist.add(user, track);
            }
            return tracklist.GetTopTracks(20);
        }
    }
}
