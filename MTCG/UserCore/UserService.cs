using System;
using System.Collections.Generic;

namespace MTCG.UserCore
{
    public static class UserService
    {
        // store registered users: key is username, value is UserDTO (data of user)
        private static Dictionary<string, UserDTO> users = new Dictionary<string, UserDTO>();
        
        // store tokens for logged in users: key is username, value is token
        private static Dictionary<string, string> tokens = new Dictionary<string, string>();

        // register new user
        public static bool RegisterUser(string username, string password)
        {
            // if username already exists
            if (users.ContainsKey(username)) return false;

            // add new user to users dictionary
            users[username] = new UserDTO { Username = username, Password = password };
            return true;
        }

        // auth user + generate login token
        public static string LoginUser(string username, string password)
        {
            // check if user exist + password match
            if (users.ContainsKey(username) && users[username].Password == password)
            {
                var token = TokenManager.GenerateToken(username);
                tokens[username] = token; // store token
                return token;
            }
            return null;
        }
    }
}