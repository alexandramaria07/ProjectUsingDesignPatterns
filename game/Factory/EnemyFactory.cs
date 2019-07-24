using Game;
using System;


namespace Game
{
    public static class EnemyFactory
    {
        public static Enemy GetEnemy(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyType.Elf:
                    return new Enemy("Elf", Constants.ElfHealthPoints, Constants.ElfAttackPoints, Constants.ElfDefencePoints);
                case EnemyType.Hydra:
                    return new Enemy("Hydra", Constants.HydraHealthPoints, Constants.HydraAttackPoints, Constants.HydraDefencePoints);
                case EnemyType.Orc:
                    return new Enemy("Orc", Constants.OrcHealthPoints, Constants.OrcAttackPoints, Constants.OrcDefencePoints);
                case EnemyType.Troll:
                    return new Enemy("Troll", Constants.TrollHealthPoints, Constants.TrollAttackPoints, Constants.TrollDefencePoints);
                case EnemyType.Wolf:
                    return new Enemy("Wolf", Constants.WolfHealthPoints, Constants.WolfAttackPoints, Constants.WolfDefencePoints);
                default:
                    throw new Exception("Enemy " + enemyType.ToString() + " was not found");
            }
        }
    }
}
