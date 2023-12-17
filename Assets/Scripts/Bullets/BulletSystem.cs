using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : Pool, IListenerFixUpdate, IListenerAwake
    {
        private LevelBounds levelBounds;

        private BulletDamage bulletDamage;

        private ServiceBullet serviceBullets;

        public BulletSystem(LevelBounds bounds, BulletDamage damage, ServiceBullet serviceBullet, Factory factory)
        {
            serviceBullets = serviceBullet;
            PoolFactory = factory;
            levelBounds = bounds;
            bulletDamage = damage;
            ListenerManager.Listeners.Add(this);
        }

        public void OnAwake()
        {
            initialCount = 50;
            InitialObjectInPool(serviceBullets.BulletPrefab, serviceBullets.BulletContainer);
        }

        public Bullet InstantiateBullet()
        {
            if (OnPoll.TryDequeue(out GameObject bullet))
            {
                bullet.transform.SetParent(serviceBullets.WorldTransform);
            }
            else
            {
                bullet = PoolFactory.Creator(serviceBullets.BulletPrefab, serviceBullets.WorldTransform);
            }

            return bullet.GetComponent<Bullet>();
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = InstantiateBullet();

            bullet.BulletLogick.BulletInit(args);

            if (ActivePools.Add(bullet.gameObject))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        public void OnFixUpdate(float deltaTime)
        {
            Cache.Clear();
            Cache.AddRange(ActivePools);

            for (int i = 0, count = Cache.Count; i < count; i++)
            {
                var bullet = Cache[i];
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveObjectInPool(bullet, serviceBullets.BulletContainer);
                }
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            bulletDamage.DealDamage(bullet, collision.gameObject);
            RemoveObjectInPool(bullet.gameObject, serviceBullets.BulletContainer);
        }
    }
}