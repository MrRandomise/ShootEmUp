using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : Pool, IListenerFixUpdate, IListenerAwake
    {
        private LevelBounds levelBounds;

        private BulletDamage bulletDamage;

        private GameObject bulletPrefab;

        public BulletSystem(LevelBounds bounds, ListenerManager manager, BulletDamage damage, ServiceBullet serviceBullet)
        {
            Container = serviceBullet.BulletContainer;
            bulletPrefab = serviceBullet.BulletPrefab;
            WorldTransform = serviceBullet.WorldTransform;
            levelBounds = bounds;
            ListenerManager = manager;
            bulletDamage = damage;
            ListenerManager.Listeners.Add(this);
        }

        public void OnAwake()
        {
            initialCount = 50;
            InitialObjectInPool(bulletPrefab);
        }

        public Bullet InstantiateBullet()
        {
            if (OnPoll.TryDequeue(out GameObject bullet))
            {
                bullet.transform.SetParent(WorldTransform);
            }
            else
            {
                bullet = MonoBehaviour.Instantiate(bulletPrefab, WorldTransform);
            }

            return bullet.GetComponent<Bullet>();
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = InstantiateBullet();

            bullet.BulletInit(args);

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
                    RemoveObjectInPool(bullet);
                }
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            bulletDamage.DealDamage(bullet, collision.gameObject);
            RemoveObjectInPool(bullet.gameObject);
        }
    }
}