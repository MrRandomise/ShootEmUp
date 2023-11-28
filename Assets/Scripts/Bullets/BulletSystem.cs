using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : BasePool
    {
        [SerializeField] private LevelBounds levelBounds;

        private BulletDamage bulletDamage = new BulletDamage();

        private void Awake()
        {
            InitialObjectInPool();
        }

        public Bullet InstantiateBullet()
        {
            if (OnPoll.TryDequeue(out GameObject bullet))
            {
                bullet.transform.SetParent(WorldTransform);
            }
            else
            {
                bullet = Instantiate(GameObjectPrefab, WorldTransform);
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

        private void FixedUpdate()
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