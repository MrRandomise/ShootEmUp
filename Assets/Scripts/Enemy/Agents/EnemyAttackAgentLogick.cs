using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgentLogick : IListenerFixUpdate
    {
        private EnemyAttackAgentComponent enemyAttack;

        private BulletSystem bulletSystem;

        public EnemyAttackAgentLogick(EnemyAttackAgentComponent component, ListenerManager listener, BulletSystem bullet)
        {
            enemyAttack = component;
            bulletSystem = bullet;
            listener.AddDynamicLisnter(this);
        }

        public void SetTarget(GameObject player)
        {
            enemyAttack.Target = player;
        }

        public void RemoveTarget()
        {
            enemyAttack.Target = null;
        }

        public void Reset()
        {
            enemyAttack.CurrentTime = enemyAttack.Countdown;
        }

        public void OnFixUpdate(float deltaTime)
        {
            if (enemyAttack.Target == null)
            {
                return;
            }

            if (!enemyAttack.MoveAgent.IsReached)
            {
                return;
            }

            if (!enemyAttack.Target.GetComponent<HitPointsComponent>().HitPointLogick.IsHitPointsExists())
            {
                return;
            }

            enemyAttack.CurrentTime -= Time.fixedDeltaTime;
            if (enemyAttack.CurrentTime <= 0)
            {
                OnAttack();
                enemyAttack.CurrentTime += enemyAttack.Countdown;
            }
        }

        private void OnAttack()
        {
            var startPosition = enemyAttack.WeaponComponent.WeaponLogick.Position;
            var vector = (Vector2)enemyAttack.Target.transform.position - startPosition;
            var direction = vector.normalized;
            enemyAttack.WeaponComponent.WeaponLogick.OnWeaponAttack(new Args
            {
                IsPlayer = false,
                PhysicsLayer = (int)enemyAttack.BulletConfig.PhysicsLayer,
                Color = enemyAttack.BulletConfig.Color,
                Damage = enemyAttack.BulletConfig.Damage,
                Position = startPosition,
                Velocity = direction * enemyAttack.BulletConfig.Speed
            });
        }
    }
}

