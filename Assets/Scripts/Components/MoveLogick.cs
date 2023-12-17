using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveLogick
    {
        private MoveComponent moveComponent;

        public MoveLogick(MoveComponent component)
        {
            moveComponent = component;
        }

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            var nextPosition = moveComponent.moveBody.position + vector * moveComponent.bodySpeed;
            moveComponent.moveBody.MovePosition(nextPosition);
        }
    }
}

