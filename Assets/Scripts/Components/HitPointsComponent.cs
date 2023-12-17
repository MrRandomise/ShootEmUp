using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public int HitPoints = 3;

        public event Action<GameObject> OnHpIsEmpty;

        public HitPointsLogick HitPointLogick => new HitPointsLogick(this);

        public void BulletDamage()
        {
            OnHpIsEmpty?.Invoke(gameObject);
        }
        
    }
}