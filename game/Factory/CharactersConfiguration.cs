using Game.Characters;
using System;
using System.Collections.Generic;

namespace Game
{
    public class CharactersConfiguration
    {
        public Hero Hero { get; private set; }
        private readonly List<Enemy> Enemies;

        private static CharactersConfiguration instance = null;
        private static readonly object lockObject = new object();

        private CharactersConfiguration()
        {
            Hero = new Hero(Constants.HeroName, Constants.HeroHealthPoints, Constants.HeroAttackPoints, new SpeedPower(), Constants.HeroDefencePoints, Constants.HeroShieldPoints);
            Enemies = new List<Enemy>();
            Enemies.Add(EnemyFactory.GetEnemy(EnemyType.Elf));
            Enemies.Add(EnemyFactory.GetEnemy(EnemyType.Hydra));
            Enemies.Add(EnemyFactory.GetEnemy(EnemyType.Orc));
            Enemies.Add(EnemyFactory.GetEnemy(EnemyType.Troll));
            Enemies.Add(EnemyFactory.GetEnemy(EnemyType.Wolf));
        }

        public List<Enemy> GetRandomEnemies(int numberOfEnemies)
        {
            var random = new Random();
            List<Enemy> enemies = new List<Enemy>();
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int randomNumber = random.Next(0, Enemies.Count);
                enemies.Add(Enemies[randomNumber]);
            }
            return enemies;
        }

        public static CharactersConfiguration Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CharactersConfiguration();
                    }
                    return instance;
                }
            }
        }
    }
}
