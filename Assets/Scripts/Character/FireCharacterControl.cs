using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireCharacterControl : IListenerEnabled, IListenerDisabled
    {
        private BulletConfig bulletConfig;

        private InputFireControl fireControl;

        private WeaponComponent weaponComponent;

        public FireCharacterControl(BulletConfig Config, InputFireControl fire, ServiceCharacter serviceCharacter, BulletSystem bulletSystem)
        {
            bulletConfig = Config;
            fireControl = fire;
            weaponComponent = serviceCharacter.CharacterWeaponComponent;
            weaponComponent.SetBulletSystem(bulletSystem);
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
            weaponComponent.OnWeaponAttack(new Args
            {
                IsPlayer = true,
                PhysicsLayer = (int)bulletConfig.PhysicsLayer,
                Color = bulletConfig.Color,
                Damage = bulletConfig.Damage,
                Position = weaponComponent.Position,
                Velocity = weaponComponent.Rotation * Vector3.up * bulletConfig.Speed
            });
        }
    }
}