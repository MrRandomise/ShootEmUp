using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions
    {
        private Transform[] spawnPositions;

        private Transform[] attackPositions;

        public EnemyPositions(ServiceEnemyPosition serviceEnemyPosition)
        {
            spawnPositions = serviceEnemyPosition.SpawnPositions;
            attackPositions = serviceEnemyPosition.AttackPositions;
        }

        public Transform RandomSpawnPosition()
        {
            return RandomTransform(spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return RandomTransform(attackPositions);
        }

        private static Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}