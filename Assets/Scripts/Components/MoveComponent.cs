using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D moveBody;

        [SerializeField] private float bodySpeed = 5.0f;

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = moveBody.position + vector * bodySpeed;
            moveBody.MovePosition(nextPosition);
        }
    }
}