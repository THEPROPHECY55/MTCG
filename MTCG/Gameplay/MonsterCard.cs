namespace MTCG.Gameplay
{
    public class MonsterCard : Card
    {
        public MonsterType MonsterType { get; set; }

        public MonsterCard(string name, double damage, ElementType element, MonsterType monsterType)
            : base(name, damage, element)
        {
            MonsterType = monsterType;
        }

        public override double CalculateDamage(Card opponentCard)
        {
            // TODO: Logic
            
            return Damage;
        }
    }
}