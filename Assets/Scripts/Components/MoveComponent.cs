using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private float speed = 5.0f;
        private Vector2 direction;

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = this.rigidbody2D.position + vector * this.speed;
            this.rigidbody2D.MovePosition(nextPosition);
        }
        
        public void Move(float horizontalDirection)
        {
            direction = new Vector2(horizontalDirection, 0) * Time.fixedDeltaTime;
        }

        private void FixedUpdate()
        {
            MoveByRigidbodyVelocity(direction);
        }
    }
}