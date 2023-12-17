using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        [NonSerialized] public bool IsPlayer;
        
        [NonSerialized] public int Damage;

        public Rigidbody2D BulletBody;

        public SpriteRenderer SpriteRenderer;

        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public BulletLogick BulletLogick => new BulletLogick(this);

        public void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }
    }
}