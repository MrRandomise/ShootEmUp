using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private int spawnTime = 1;
        private readonly HashSet<GameObject> m_activeEnemies = new();
        
        private void Start()
        {
            StartCoroutine(EnemyCreated());
        }

        private IEnumerator EnemyCreated() {
            while (true) {
                yield return new WaitForSeconds(spawnTime);
                var enemy = enemyPool.SpawnEnemy();
                if (enemy != null) {
                    if (m_activeEnemies.Add(enemy)) {
                        enemy.GetComponent<HitPointsComponent>().HpIsEmpty += OnDestroyed;
                    }
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpIsEmpty -= OnDestroyed;
                enemyPool.UnspawnEnemy(enemy);
            }
        }
    }
}