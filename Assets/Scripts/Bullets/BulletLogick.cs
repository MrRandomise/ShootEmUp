using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletLogick
    {
        private Bullet bullet;

        public BulletLogick(Bullet bull)
        {
            bullet = bull;
        }

        private void SetVelocity(Vector2 velocity)
        {
            bullet.BulletBody.velocity = velocity;
        }

        private void SetPhysicsLayer(int physicsLayer)
        {
            bullet.gameObject.layer = physicsLayer;
        }

        private void SetPosition(Vector3 position)
        {
            bullet.transform.position = position;
        }

        private void SetColor(Color color)
        {
            bullet.SpriteRenderer.color = color;
        }

        public void BulletInit(Args args)
        {
            bullet.IsPlayer = args.IsPlayer;
            bullet.Damage = args.Damage;
            SetVelocity(args.Velocity);
            SetPhysicsLayer(args.PhysicsLayer);
            SetPosition(args.Position);
            SetColor(args.Color);
        }
    }
}