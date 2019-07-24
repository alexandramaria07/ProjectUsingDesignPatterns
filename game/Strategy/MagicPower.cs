namespace Game
    public class MagicPower : ISuperPower
    {
        private const string SUPER_POWER_MESSAGE="***MAGIC***";
        public SuperPower SuperPower { get; private set; }

        public MagicPower()
        {
            SuperPower = new SuperPower(GetType().Name, Constants.MagicPowerAttackPoints);
        }
        public SuperPower AttackWithSuperPower()
        {
            System.Console.WriteLine(SUPER_POWER_MESSAGE);
            return SuperPower;
        }
    }
}
