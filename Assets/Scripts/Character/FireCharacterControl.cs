using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireCharacterControl : MonoBehaviour, IListenerEnabled, IListenerDisabled
    {
        [SerializeField] private BulletConfig bulletConfig;

        [SerializeField] private InputFireControl fireControl;

        [SerializeField] private WeaponComponent weaponComponent;

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