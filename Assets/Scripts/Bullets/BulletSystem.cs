using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private BulletPool bulletPool;
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
                bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.OnCollisionEntered -= this.OnBulletCollision;
            bulletDamage.DealDamage(bullet, collision.gameObject);
            bulletPool.RemoveBullet(bullet);
        }
    }
}