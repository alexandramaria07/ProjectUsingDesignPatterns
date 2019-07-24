using System;

namespace Game.Characters
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int HealthPoints { get; protected set; }
        public int AttackPoints { get; private set; }
        public int DefencePoints { get; protected set; }

        public Character(string name, int healthPoints, int attackPoints, int defencePoints)
        {
            Name = name;
            HealthPoints = healthPoints;
            AttackPoints = attackPoints;
            DefencePoints = defencePoints;
        }

        public int Attack()
        {
            Console.WriteLine(Name + " attacks...");
            return AttackPoints;
        }

        public bool IsAlive()
        {
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                return false;
            }
            return true;
        }
    }
}
