using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponLogick
    {
        private WeaponComponent weaponComponent;

        private BulletSystem bulletSystem;

        public WeaponLogick(WeaponComponent component, BulletSystem bullet)
        {
            weaponComponent = component;
            bulletSystem = bullet;
        }

        public Vector2 Position
        {
            get { return weaponComponent.FirePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return weaponComponent.FirePoint.rotation; }
        }

        public void OnWeaponAttack(Args bulletArgs)
        {
            bulletSystem.FlyBulletByArgs(bulletArgs);
        }
    }
}
