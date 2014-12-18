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
        private List<LastFmApiClient.Track> _lovedTracks;

        public UserData(string username, List<LastFmApiClient.Track> lovedTracks)
        {
            _username = username;
            _lovedTracks = lovedTracks;
        }

        public string username { get { return _username; } }
        public List<LastFmApiClient.Track> lovedTracks { get { return _lovedTracks; } }


    }
}
