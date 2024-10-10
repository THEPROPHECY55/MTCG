﻿using System.Collections.Generic;

namespace MTCG
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int ELO { get; set; } = 100;
        public int Coins { get; set; } = 20;
        public List<Card> Stack { get; set; }
        public List<Card> Deck { get; set; }
        public UserProfile Profile { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Stack = new List<Card>();
            Deck = new List<Card>();
            Profile = new UserProfile();
        }
        
        // TODO: Methoden 12
    }
}