using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireCharacterControl : MonoBehaviour
    {
        [SerializeField] private BulletConfig bulletConfig;

        [SerializeField] private InputFireControl fireControl;

        [SerializeField] private WeaponComponent weaponComponent;

        private void OnEnable()
        {
            fireControl.OnFireAction += OnAttack;
        }

        private void OnDisable()
        {
            fireControl.OnFireAction -= OnAttack;
        }
        
        private void OnAttack()
        {
            weaponComponent.OnWeaponAttack(new Args
            {
                IsPlayer = true,
                PhysicsLayer = (int) PhysicsLayer.PLAYER_BULLET,
                Color = Color.blue,
                Damage = 1,
                Position = weaponComponent.Position,
                Velocity = weaponComponent.Rotation * Vector3.up * bulletConfig.Speed
            });
        }
    }
}