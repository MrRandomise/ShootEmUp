using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : BasePool, IListenerStart, IListenerAwake
    {

        [SerializeField] private int spawnTime = 1;

        [SerializeField] private EnemyPositions enemyPositions;

        [SerializeField] private GameObject character;

        [SerializeField] private ListenerInstaller listenerInstaller;

        private readonly HashSet<GameObject> activeEnemies = new();

        public void OnAwake()
        {
            InitialObjectInPool();
        }

        public void OnStart()
        {
            StartCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTime);
                if (TrySpawnyEnemy(out var enemy))
                {
                    if (activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().OnHpIsEmpty += OnDestroyed;
                        listenerInstaller.AddDynamicLisnter(enemy);
                    }
                }
            }
        }

        private bool TrySpawnyEnemy(out GameObject enemy)
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
                enemy.GetComponent<HitPointsComponent>().OnHpIsEmpty -= OnDestroyed;
                UnspawnEnemy(enemy);
            }
        }
    }
}