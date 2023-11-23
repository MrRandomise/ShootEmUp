using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private float countdown;
        public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);
        private WeaponComponent weaponComponent;
        private EnemyMoveAgent moveAgent;

        private GameObject target;
        private float currentTime;

        private void Awake()
        {
            weaponComponent = GetComponent<WeaponComponent>();
            moveAgent = GetComponent<EnemyMoveAgent>();
        }

        public void SetTarget(GameObject target)
        {
            this.target = target;
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
                return;
            }

            currentTime -= Time.fixedDeltaTime;
            if (currentTime <= 0)
            {
                OnAtack();
                currentTime += countdown;
            }
        }

        private void OnAtack()
        {
            var startPosition = weaponComponent.Position;
            var vector = (Vector2) target.transform.position - startPosition;
            var direction = vector.normalized;
            weaponComponent.OnWeaponAtack(new Args
            {
                isPlayer = false,
                physicsLayer = (int) PhysicsLayer.ENEMY_BULLET,
                color = Color.red,
                damage = 1,
                position = startPosition,
                velocity = direction * 2.0f
            });
        }
    }
}