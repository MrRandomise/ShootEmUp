using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        public Rigidbody2D moveBody;

        public float bodySpeed = 5.0f;

        public MoveLogick MoveLogick => new MoveLogick(this);
    }
}