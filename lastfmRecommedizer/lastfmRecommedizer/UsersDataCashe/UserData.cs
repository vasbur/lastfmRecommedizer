using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.UsersDataCashe
{
    class UserData
    {
        private string _username;
        private List<TrackInfo> _lovedTracks;
        private List<TrackInfo> _bannedTracks;
        private List<TrackInfo> _listenedTracks;

        public UserData(string username, List<TrackInfo> lovedTracks, List<TrackInfo> bannedTracks, List<TrackInfo> listenedTracks)
        {
            _username = username;
            _lovedTracks = lovedTracks;
            _bannedTracks = bannedTracks;
            _listenedTracks = listenedTracks;
        }

        public string username { get { return _username; } }
        public List<TrackInfo> lovedTracks { get { return _lovedTracks; } }
        public List<TrackInfo> bannedTracks { get { return _bannedTracks; } }
        public List<TrackInfo> listenedTracks { get { return _listenedTracks; } }


    }
}
