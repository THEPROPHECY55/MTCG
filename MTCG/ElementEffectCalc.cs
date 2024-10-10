using System.Security.AccessControl;

namespace MTCG
{
    public static class ElementEffectCalc
    {
        public static double GetEffectivenessMultiplier(ElementType attacker, ElementType defender)
        {
            if (attacker == ElementType.Water && defender == ElementType.Fire)
                return 2.0;
            if (attacker == ElementType.Fire && defender == ElementType.Normal)
                return 2.0;
            if (attacker == ElementType.Normal && defender == ElementType.Water)
                return 2.0;
            
            
            if (defender == ElementType.Water && attacker == ElementType.Fire)
                return 0.5;
            if (defender == ElementType.Fire && attacker == ElementType.Normal)
                return 0.5;
            if (defender == ElementType.Normal && attacker == ElementType.Water)
                return 0.5;
            
            return 1.0;
        }
    }

}