using UnityEngine;
namespace ShootEmUp
{
    public sealed class EnemyMoveAgentLogick : IListenerFixUpdate
    {
        private EnemyMoveAgentComponent enemyMoveAgentComponent;

        public EnemyMoveAgentLogick(EnemyMoveAgentComponent component, ListenerManager listener)
        {
            enemyMoveAgentComponent = component;
            listener.AddDynamicLisnter(this);
        }

        public void SetDestination(Vector2 endPoint)
        {
            enemyMoveAgentComponent.Destination = endPoint;
            enemyMoveAgentComponent.IsReached = false;
        }

        public void OnFixUpdate(float deltaTime)
        {
            
            if (enemyMoveAgentComponent.IsReached)
            {
                return;
            }

            var vector = enemyMoveAgentComponent.Destination - (Vector2)enemyMoveAgentComponent.transform.position;
            if (vector.magnitude <= enemyMoveAgentComponent.Magnitude)
            {
                enemyMoveAgentComponent.IsReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            enemyMoveAgentComponent.MoveComponent.MoveLogick.MoveByRigidbodyVelocity(direction);
        }
    }
}

