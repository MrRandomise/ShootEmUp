using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : BasePool
    {

        [SerializeField] private int spawnTime = 1;

        [SerializeField] private EnemyPositions enemyPositions;

        [SerializeField] private GameObject character;

        private readonly HashSet<GameObject> activeEnemies = new();


        private void Awake()
        {
            InitialObjectInPool();
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                if (SpawnEnemy(out var enemy))
                {
                    if (activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().HpIsEmpty += OnDestroyed;
                    }
                }
            }
        }

        private bool SpawnEnemy(out GameObject enemy)
        {
            if (!OnPoll.TryDequeue(out enemy))
            {
                return false;
            }

            enemy.transform.SetParent(WorldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(character);
            return true;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(Container);
            OnPoll.Enqueue(enemy);
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpIsEmpty -= OnDestroyed;
                UnspawnEnemy(enemy);
            }
        }
    }
}