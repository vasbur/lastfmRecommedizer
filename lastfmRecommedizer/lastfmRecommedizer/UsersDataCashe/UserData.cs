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

        public UserData(string username, List<TrackInfo> lovedTracks)
        {
            _username = username;
            _lovedTracks = lovedTracks;
        }

        public string username { get { return _username; } }
        public List<TrackInfo> lovedTracks { get { return _lovedTracks; } }


    }
}
