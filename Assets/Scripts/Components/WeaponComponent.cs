using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;

        private BulletSystem bulletSystem;

        private void Awake()
        {
            bulletSystem = FindObjectOfType<BulletSystem>();
        }

        public Vector2 Position
        {
            get { return firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return firePoint.rotation; }
        }

        public void OnWeaponAttack(Args bulletArgs)
        {
            bulletSystem.FlyBulletByArgs(bulletArgs);
        }
    }
}