using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.UsersDataCashe
{
    class UserRequest
    {
        private string username;
        Task<UserData> UserDataTask;

        public UserRequest(string username)
        {
            this.username = username;
            UserDataTask = new Task<UserData>(GetUserData, username);

        }

        private UserData GetUserData(object obj)
        {
            return User.getUser((string)obj);
        }

        public void Start()
        {
            UserDataTask.Start();
        }

        public UserData GetResult()
        {
            UserDataTask.Wait();
            return UserDataTask.Result; 
        }
    }
}
