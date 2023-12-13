using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

namespace ShootEmUp
{
    public sealed class EnemyManager : Pool, IListenerAwake, IListenerUpdate, IListenerStart
    {
        private float initSpawnTime = 1;

        private float spawnTime = 1;

        private GameObject enemyPrefab;

        private EnemyPositions enemyPositions;

        private GameObject character;

        private readonly HashSet<GameObject> activeEnemies = new();

        private ServiceEnemy serviceEnemy;

        private BulletSystem bulletSystem;


        public EnemyManager(ServiceEnemy service, ListenerManager manager, EnemyPositions position, BulletSystem bullet)
        {
            enemyPositions = position;
            ListenerManager = manager;
            serviceEnemy = service;
            bulletSystem = bullet;
            enemyPrefab = serviceEnemy.EnemyPrefab;
            Container = serviceEnemy.EnemyContainer;
            WorldTransform = serviceEnemy.WorldTransform;
            Container = serviceEnemy.EnemyContainer;
            character = serviceEnemy.Character;
            ListenerManager.Listeners.Add(this);
        }

        public void OnAwake()
        {
            initialCount = 7;
            InitialObjectInPool(enemyPrefab);
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

            enemy.transform.SetParent(WorldTransform);

            var spawnPosition = enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = enemyPositions.RandomAttackPosition();

            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<WeaponComponent>().SetBulletSystem(bulletSystem);

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
                enemy.GetComponent<EnemyAttackAgent>().RemoveTarget();
                UnspawnEnemy(enemy);
            }
        }
    }
}