using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour, IListenerFixUpdate
    {
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private LevelBounds levelBounds;

        private BulletDamage bulletDamage = new BulletDamage();

        public void FlyBulletByArgs(Args args)
        {
            if (bulletPool.m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(bulletPool.worldTransform);
            }
            else
            {
                bullet = Instantiate(bulletPool.prefab, bulletPool.worldTransform);
            }

            bullet.BulletInit(args);
            
            if (bulletPool.m_activeBullets.Add(bullet))
            
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        public void OnFixUpdate()
        {
            bulletPool.m_cache.Clear();
            bulletPool.m_cache.AddRange(bulletPool.m_activeBullets);

            for (int i = 0, count = bulletPool.m_cache.Count; i < count; i++)
            {
                var bullet = bulletPool.m_cache[i];
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    bulletPool.RemoveBullet(bullet);
                }
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            bulletDamage.DealDamage(bullet, collision.gameObject);
            bulletPool.RemoveBullet(bullet);
        }
    }
}