using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        private BulletSystem bulletSystem;
        public int test = 5;
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

        public void OnWeaponAtack(Args bulletArgs)
        {
            bulletSystem.FlyBulletByArgs(bulletArgs);
        }
    }
}