using Game;
using Game.Characters;
using System;

namespace Game.Characters
{
    public class Enemy : Character, IDefender
    {
        public Enemy(string name, int healthPoints, int attackPoints, int defencePoints) : base(name, healthPoints, attackPoints, defencePoints)
        {
        }

        public void Defend(int attackPoints)
        {
            Console.WriteLine("Enemy " + Name + " is defending....");

            if (attackPoints >= DefencePoints)
            {
                HealthPoints -= attackPoints - DefencePoints;
                DefencePoints = 0;
            }
            else
            {
                DefencePoints -= attackPoints;
            }

            GetEnemyStatus();
        }

        public void GetEnemyStatus()
        {
            if (IsAlive())
            {
                Console.WriteLine($"Enemy {Name} [ healthPoints: {HealthPoints}, defencePoints: {DefencePoints}, attackPoints: {AttackPoints} ]");
            }
            else
            {
                Console.WriteLine($"Enemy {Name} is dead!");
            }
        }
    }
}
