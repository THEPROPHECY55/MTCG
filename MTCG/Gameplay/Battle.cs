using System;
using System.Collections.Generic;
using MTCG.UserCore;

namespace MTCG.Gameplay
{
    public class Battle
    {
        public User Player1 { get; set; }
        public User Player2 { get; set; }

        public List<string> BattleLog { get; set; }

        public Battle(User player1, User player2)
        {
            Player1 = player1;
            Player2 = player2;
            BattleLog = new List<string>();
        }

        public void StartBattle()
        {
            for (int i = 0; i < 100 && Player1.Deck.Count > 0 && Player2.Deck.Count > 0; i++)
            {
                Card card1 = GetRandomCard(Player1.Deck);
                Card card2 = GetRandomCard(Player2.Deck);

                double damage1 = card1.CalculateDamage(card2);
                double damage2 = card2.CalculateDamage(card1);

                if (damage1 > damage2)
                {
                    // Player1 wins round
                    Player1.Deck.Add(card2);
                    Player2.Deck.Remove(card2);
                    BattleLog.Add($"{card1.Name} wins against {card2.Name}");
                }
                else if (damage2 > damage1)
                {
                    // Player2 wins round
                    Player2.Deck.Add(card1);
                    Player1.Deck.Remove(card1);
                    BattleLog.Add($"{card2.Name} wins against {card1.Name}");
                }
                else
                {
                    BattleLog.Add($"{card1.Name} and {card2.Name} resulted in a draw");
                }
            }

            UpdateELO();
        }

        private void UpdateELO() // TODO: Custom ELO
        {
            if (Player1.Deck.Count > Player2.Deck.Count)
            {
                Player1.ELO += 3;
                Player2.ELO -= 5;
            }
            else if (Player2.Deck.Count > Player1.Deck.Count)
            {
                Player2.ELO += 3;
                Player1.ELO -= 5;
            }
        }

        private Card GetRandomCard(List<Card> deck)
        {
            Random rand = new Random();
            return deck[rand.Next(deck.Count)];
        }
    }

}