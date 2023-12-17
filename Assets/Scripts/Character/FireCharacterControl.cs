using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireCharacterControl : IListenerEnabled, IListenerDisabled
    {
        private BulletConfig bulletConfig;

        private InputFireControl fireControl;

        private WeaponComponent weaponComponent;

        private BulletSystem bulletSystem;

        public FireCharacterControl(BulletConfig Config, InputFireControl fire, ServiceCharacter serviceCharacter, BulletSystem bullet)
        {
            bulletConfig = Config;
            fireControl = fire;
            weaponComponent = serviceCharacter.CharacterWeaponComponent;
            bulletSystem = bullet;
            ListenerManager.Listeners.Add(this);
        }

        public void ListenerEnabled()
        {
            fireControl.OnFireAction += OnAttack;
        }

        public void ListenerDisabled()
        {
            fireControl.OnFireAction -= OnAttack;
        }
        
        private void OnAttack()
        {
            weaponComponent.WeaponLogick.OnWeaponAttack(new Args
            {
                IsPlayer = true,
                PhysicsLayer = (int)bulletConfig.PhysicsLayer,
                Color = bulletConfig.Color,
                Damage = bulletConfig.Damage,
                Position = weaponComponent.WeaponLogick.Position,
                Velocity = weaponComponent.WeaponLogick.Rotation * Vector3.up * bulletConfig.Speed
            });
        }
    }
}