
﻿using System;
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
        public bool RenameUser(string oldUsername, string newUsername, IPEndPoint endpoint = null)
        {
            if (string.IsNullOrEmpty(newUsername) || newUsername == oldUsername)
                return false;

            if (connectedUsers.Contains(newUsername) && newUsername != oldUsername)
                return false;

            if (connectedUsers.Contains(oldUsername))
            {
                connectedUsers.Remove(oldUsername);
                connectedUsers.Add(newUsername);

                if (userEndpoints.ContainsKey(oldUsername))
                {
                    var oldEndpoint = userEndpoints[oldUsername];
                    userEndpoints.Remove(oldUsername);
                    userEndpoints[newUsername] = endpoint ?? oldEndpoint;
                }
                else if (endpoint != null)
                {
                    userEndpoints[newUsername] = endpoint;
                }

                return true;
            }
            return false;
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