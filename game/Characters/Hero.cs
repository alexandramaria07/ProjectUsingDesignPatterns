using System;

namespace Game.Characters
{
    public class Hero : Character, IDefender
    {
        public int ShieldPoints { get; private set; }
        public ISuperPower SuperPower { get; private set; }
        private SuperPower _superPowerObject;

        public Hero(string name, int healthPoints, int attackPoints, ISuperPower superPower, int defencePoints, int shieldPoints) : base(name, healthPoints, attackPoints, defencePoints)
        {
            ShieldPoints = shieldPoints;
            SuperPower = superPower;
            SetSuperPowerObject();
        }

        public void Defend(int attackPoints)
        {
            Console.WriteLine("Hero " + Name + " is defending...");

            if (attackPoints > ShieldPoints)
            {
                ShieldIsPenetrated(attackPoints);
            }
            else
            {
                ShieldPoints -= attackPoints;
            }

            GetHeroStatus();
        }

        private void ShieldIsPenetrated(int attackPoints)
        {
            if (attackPoints > DefencePoints + ShieldPoints)
            {
                HealthPoints -= attackPoints - DefencePoints;
                DefencePoints = 0;
            }
            else
            {
                DefencePoints = ShieldPoints - attackPoints + DefencePoints;
            }

            ShieldPoints = 0;
        }

        public void GetHeroStatus()
        {
            if (IsAlive())
            {
                Console
                .WriteLine($"Hero {Name} [ healthPoints: {HealthPoints}, defencePoints: {DefencePoints}, attackPoints: {AttackPoints}, shieldPoints: {ShieldPoints}, superPower: {_superPowerObject.PowerName} ({_superPowerObject.AttackPoints}) ]");
            }
            else
            {
                Console.WriteLine($"Hero {Name} is dead!");
            }
        }

        public int AttackWithSuperPower()
        {
            System.Console.WriteLine($"Hero attacks with superpower:{_superPowerObject.PowerName}");

            return _superPowerObject.AttackPoints;
        }

        private void SetSuperPowerObject()
        {
            _superPowerObject = SuperPower.AttackWithSuperPower();
        }

        public void SetSuperPower(ISuperPower superPower)
        {
            SuperPower = superPower;
            SetSuperPowerObject();
        }
    }
}
