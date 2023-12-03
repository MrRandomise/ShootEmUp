using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IListenerFixUpdate
    {
        public bool IsReached
        {
            get { return isReached; }
        }

        [SerializeField] private float magnitude = 0.25f;

        [SerializeField] private MoveComponent moveComponent;

        private Vector2 destination;

        private bool isReached;

        public void SetDestination(Vector2 endPoint)
        {
            destination = endPoint;
            isReached = false;
        }

        public void OnFixUpdate(float deltaTime)
        {
            if (isReached)
            {
                return;
            }
            
            var vector = destination - (Vector2) transform.position;
            if (vector.magnitude <= magnitude)
            {
                isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}