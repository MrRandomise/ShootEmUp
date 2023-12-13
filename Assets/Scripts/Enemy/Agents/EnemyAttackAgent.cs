using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour, IListenerFixUpdate
    {
        [SerializeField] private WeaponComponent weaponComponent;

        [SerializeField] private EnemyMoveAgent moveAgent;

        [SerializeField] private BulletConfig bulletConfig;

        [SerializeField] private float countdown = 1;

        private GameObject target = null;

        private float currentTime;

        public void SetTarget(GameObject player)
        {
            target = player;
        }

        public void RemoveTarget()
        {
            target = null;
        }

        public void Reset()
        {
            currentTime = countdown;
        }

        public void OnFixUpdate(float deltaTime)
        {
            if (target == null)
            {
                return;
            }

            if (!moveAgent.IsReached)
            {
                return;
            }

            if (!target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            currentTime -= Time.fixedDeltaTime;
            if (currentTime <= 0)
            {
                OnAttack();
                currentTime += countdown;
            }
        }

        private void OnAttack()
        {
            var startPosition = weaponComponent.Position;
            var vector = (Vector2) target.transform.position - startPosition;
            var direction = vector.normalized;
            weaponComponent.OnWeaponAttack(new Args
            {
                IsPlayer = false,
                PhysicsLayer = (int)bulletConfig.PhysicsLayer,
                Color = bulletConfig.Color,
                Damage = bulletConfig.Damage,
                Position = startPosition,
                Velocity = direction * bulletConfig.Speed
            });
        }
    }
}