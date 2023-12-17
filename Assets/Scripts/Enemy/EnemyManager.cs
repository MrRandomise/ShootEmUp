using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : Pool, IListenerAwake, IListenerUpdate, IListenerStart
    {
        private float initSpawnTime = 1;

        private float spawnTime = 1;

        private EnemyPositions enemyPositions;

        private readonly HashSet<GameObject> activeEnemies = new();

        private ServiceEnemy serviceEnemy;


        public EnemyManager(ServiceEnemy service, EnemyPositions position, Factory factory)
        {
            PoolFactory = factory;
            enemyPositions = position;
            serviceEnemy = service;
            ListenerManager.Listeners.Add(this);
        }

        public void OnAwake()
        {
            initialCount = 7;
            InitialObjectInPool(serviceEnemy.EnemyPrefab, serviceEnemy.EnemyContainer);
        }
        
        public void OnStart()
        {
            initSpawnTime = spawnTime;
        }

        public void OnUpdate(float deltaTime)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                spawnTime = initSpawnTime;
                if (TrySpawnyEnemy(out var enemy))
                {
                    if (activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().OnHpIsEmpty += OnDestroyed;
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

            enemy.transform.SetParent(serviceEnemy.WorldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = enemyPositions.RandomAttackPosition();

            enemy.GetComponent<EnemyMoveAgentComponent>().EnemyMove.SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgentComponent>().EnemyAttack.SetTarget(serviceEnemy.Character);

            return true;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(serviceEnemy.EnemyContainer);
            OnPoll.Enqueue(enemy);
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHpIsEmpty -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgentComponent>().EnemyAttack.RemoveTarget();
                UnspawnEnemy(enemy);
            }
        }
    }
}