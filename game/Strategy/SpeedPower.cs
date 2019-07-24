namespace Game
{
    public class SpeedPower : ISuperPower
    {
        public SuperPower SuperPower { get; private set; }
        public SpeedPower()
        {
            SuperPower = new SuperPower(GetType().Name, Constants.SpeedPowerAttackPoints);
        }
        public SuperPower AttackWithSuperPower()
        {
            return SuperPower;
        }
    }
}
