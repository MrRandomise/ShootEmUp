using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{

    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private int initialCount = 50;
        [SerializeField] private Transform container;
        public Bullet prefab;
        public Transform worldTransform;
        public  HashSet<Bullet> m_activeBullets = new();
        public readonly Queue<Bullet> m_bulletPool = new();
        public readonly List<Bullet> m_cache = new();
        
        private void Awake()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, container);
                m_bulletPool.Enqueue(bullet);
            }
        }

        public void RemoveBullet(Bullet bullet)
        {
            if (m_activeBullets.Remove(bullet))
            {
                bullet.transform.SetParent(container);
                m_bulletPool.Enqueue(bullet);
            }
        }
    }
}