using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D MoveBody;

        [SerializeField] private float speed = 5.0f;

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = MoveBody.position + vector * speed;
            MoveBody.MovePosition(nextPosition);
        }
    }
}