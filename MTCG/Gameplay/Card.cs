namespace MTCG.Gameplay
{
    public abstract class Card
    {
        public string Name { get; set; } // MAKE SETTERS PRIVATE?
        public double Damage { get; set; }
        public ElementType Element { get; set; }

        protected Card(string name, double damage, ElementType element)
        {
            Name = name;
            Damage = damage;
            Element = element;
        }

        public abstract double CalculateDamage(Card opponentCard);
    }
}