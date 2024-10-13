using System;
using MTCG.UserCore;

namespace MTCG.Gameplay
{
    public class Trade
    {
        public User Initiator { get; set; }
        public Card OfferedCard { get; set; }
        public Func<Card, bool> TradeRequirement { get; set; }

        public Trade(User initiator, Card offeredCard, Func<Card, bool> tradeRequirement)
        {
            Initiator = initiator;
            OfferedCard = offeredCard;
            TradeRequirement = tradeRequirement;
        }

        public bool TryTrade(User responder, Card offeredCard)
        {
            if (TradeRequirement(offeredCard)) // Rework
            {
                Initiator.Stack.Add(offeredCard);
                responder.Stack.Add(OfferedCard);
                return true;
            }

            return false;
        }
        
        /*
         var trade = new Trade(
            initiatorUser,
            initiatorCard,
            card => card.Damage > 50 && card is MonsterCard
        );
        */
    }

}