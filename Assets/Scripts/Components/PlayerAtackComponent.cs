using UnityEngine;
namespace ShootEmUp
{
    public class PlayerAtackComponent : MonoBehaviour
    {
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;

        public void Atack()
        {
            var weapon = GetComponent<WeaponComponent>();
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int) this.bulletConfig.physicsLayer,
                color = this.bulletConfig.color,
                damage = this.bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * this.bulletConfig.speed
            });
        }
    }
}
