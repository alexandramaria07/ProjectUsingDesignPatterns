namespace Game
{
    public class SuperPower
    {
        public string PowerName { get; private set; }
        public int AttackPoints { get; private set; }

        public SuperPower(string powerName, int attackPoints)
        {
            PowerName = powerName;
            AttackPoints = attackPoints;
        }
    }
}
