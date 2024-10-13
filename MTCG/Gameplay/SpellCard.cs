namespace MTCG.Gameplay
{
    public class SpellCard : Card
    {
        public SpellCard(string name, double damage, ElementType element)
            : base(name, damage, element)
        {
        }

        public override double CalculateDamage(Card opponentCard)
        {
            // TODO: Logic
            
            return CalculateElementEffectiveness(opponentCard);
        }

        private double CalculateElementEffectiveness(Card opponentCard)
        {
            if (opponentCard is MonsterCard)
            {
                // TODO: Logic
                
                return ElementEffectCalc.GetEffectivenessMultiplier(Element, opponentCard.Element) * Damage;
            }
            return Damage;
        }
    }

}