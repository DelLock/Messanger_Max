using System;
using System.Collections.Generic;
using System.Net;

namespace MessengerApp
{
    public class UserManager
    {
        private List<string> connectedUsers;
        private Dictionary<string, IPEndPoint> userEndpoints;

        public UserManager()
        {
            connectedUsers = new List<string>();
            userEndpoints = new Dictionary<string, IPEndPoint>();
        }

        public void AddUser(string username, IPEndPoint endpoint)
        {
            if (!connectedUsers.Contains(username))
            {
                connectedUsers.Add(username);
                userEndpoints[username] = endpoint;
            }
        }

        public void RemoveUser(string username)
        {
            connectedUsers.Remove(username);
            userEndpoints.Remove(username);
        }

        public List<string> GetConnectedUsers()
        {
            return new List<string>(connectedUsers);
        }

        public IPEndPoint GetUserEndpoint(string username)
        {
            return userEndpoints.ContainsKey(username) ? userEndpoints[username] : null;
        }

        public bool UserExists(string username)
        {
            return connectedUsers.Contains(username);
        }
    }
}