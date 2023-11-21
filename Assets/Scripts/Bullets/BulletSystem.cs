using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        private BulletPool bulletPool;
        private BulletDamage bulletDamage = new BulletDamage();
        
        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }

        private void Awake()
        {
            bulletPool = GetComponent<BulletPool>();
        }


        public void InitialBullet(Args args)
        {
            if (bulletPool.m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(bulletPool.worldTransform);
            }
            else
            {
                bullet = Instantiate(bulletPool.prefab, bulletPool.worldTransform);
            }

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.damage = args.damage;
            bullet.isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
            
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