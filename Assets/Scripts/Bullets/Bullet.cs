using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [NonSerialized] public bool IsPlayer;
        
        [NonSerialized] public int Damage;

        [SerializeField] private Rigidbody2D bulletBody;

        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        private void SetVelocity(Vector2 velocity)
        {
            bulletBody.velocity = velocity;
        }

        private void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        private void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        private void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        
        public void BulletInit(Args args)
        {
            IsPlayer = args.IsPlayer;
            Damage = args.Damage;
            SetVelocity(args.Velocity);
            SetPhysicsLayer(args.PhysicsLayer);
            SetPosition(args.Position);
            SetColor(args.Color);
        }
    }
}