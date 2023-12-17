using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletDamage
    {
        public void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.HitPointLogick.TakeDamage(bullet.Damage);
            }
        }
    }
}