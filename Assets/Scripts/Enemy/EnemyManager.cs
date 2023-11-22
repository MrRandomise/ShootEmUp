using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;

        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private int spawnTime = 1;
        private readonly HashSet<GameObject> m_activeEnemies = new();
        
        private void Start()
        {
            StartCoroutine(EnemyCreated());
        }

        private IEnumerator EnemyCreated() {
            while (true) {
                yield return new WaitForSeconds(spawnTime);
                var enemy = this.enemyPool.SpawnEnemy();
                if (enemy != null) {
                    if (m_activeEnemies.Add(enemy)) {
                        enemy.GetComponent<HitPointsComponent>().HpIsEmpty += OnDestroyed;
                        enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpIsEmpty -= this.OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;

                enemyPool.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            bulletSystem.OnBulletCollision(new Args
            {
                isPlayer = false,
                physicsLayer = (int) PhysicsLayer.ENEMY_BULLET,
                color = Color.red,
                damage = 1,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}