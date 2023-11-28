using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private float countdown = 1;

        [SerializeField] private WeaponComponent weaponComponent;

        [SerializeField] private EnemyMoveAgent moveAgent;

        private GameObject target;

        private float currentTime;

        public void SetTarget(GameObject player)
        {
            target = player;
        }

        public void Reset()
        {
            currentTime = countdown;
        }

        private void FixedUpdate()
        {
            if (!moveAgent.IsReached)
            {
                return;
            }

            if (!target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                print("test1");
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
                PhysicsLayer = (int) PhysicsLayer.ENEMY_BULLET,
                Color = Color.red,
                Damage = 1,
                Position = startPosition,
                Velocity = direction * 2.0f
            });
        }
    }
}