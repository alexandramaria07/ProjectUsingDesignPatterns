using Game;
using System;
using System.Collections.Generic;

namespace RPG_Game
{
    public class Game
    {
        private Hero hero;
        private List<Enemy> enemies;

        public void NewGame()
        {
            PrepareBattleField();
            StartFight();
            GetWinner();
        }

        private void PrepareBattleField()
        {
            GetHero();
            GetEnemies();
        }

        private void GetHero()
        {
            hero = CharactersConfiguration.Instance.Hero;
            hero.GetHeroStatus();

            Console.WriteLine();
        }

        private void GetEnemies()
        {
            enemies = CharactersConfiguration.Instance.GetRandomEnemies(Constants.NumberOfEnemies);
            ShowInfoAboutEnemies();
        }

        private void ShowInfoAboutEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                Console.WriteLine("Created enemy: " + enemy.Name);
                enemy.GetEnemyStatus();
            }

            Console.WriteLine();
        }

        private void StartFight()
        {
            while (!IsEndGame())
            {
                foreach (Enemy enemy in enemies)
                {
                    if (CheckIfHeroAndEnemyAreAlive(enemy))
                    {
                        int damagePointsFromHero = hero.AttackWithSuperPower();
                        enemy.Defend(damagePointsFromHero);
                    }
                    if (CheckIfHeroAndEnemyAreAlive(enemy))
                    {
                        int damagePointsFromEnemy = enemy.Attack();
                        hero.Defend(damagePointsFromEnemy);
                    }
                }
            }
        }

        private bool CheckIfHeroAndEnemyAreAlive(Enemy enemy)
        {
            return hero.IsAlive() && enemy.IsAlive();
        }

        private bool IsEndGame()
        {
            return hero.HealthPoints <= 0 || enemies.TrueForAll(e => e.HealthPoints <= 0);
        }

        private void GetWinner()
        {
            if (hero.IsAlive())
            {
                Console.WriteLine($"\nHero {hero.Name} is the winner!");
                GetAwardForHero();
                hero.GetHeroStatus();
            }
            else
            {
                Console.WriteLine("You lost. Try again.");
            }
            System.Console.WriteLine("\nGame Ended!");
        }

        private void GetAwardForHero()
        {
            hero.SetSuperPower(new MagicPower());
            System.Console.WriteLine("Hero gets a new super power!");
        }
    }
}
