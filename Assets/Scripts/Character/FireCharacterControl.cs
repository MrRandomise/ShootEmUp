using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireCharacterControl : MonoBehaviour, Listeners.IListenerStart, Listeners.IListenerStop
    {
        [SerializeField] private BulletConfig bulletConfig;

        [SerializeField] private InputFireControl fireControl;

        [SerializeField] private WeaponComponent weaponComponent;

        public void OnStart()
        {
            fireControl.OnFireAction += OnAttack;
        }

        public void OnStop()
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