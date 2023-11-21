using UnityEngine;

namespace ShootEmUp
{
    public class BulletDamage
    {
        public void DealDamage(Bullet bullet, GameObject other)
        {
            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.damage);
            }
        }
    }
}