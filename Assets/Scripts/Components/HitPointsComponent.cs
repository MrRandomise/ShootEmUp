using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> OnHpIsEmpty;
        
        [SerializeField] private int HitPoints;
        
        public bool IsHitPointsExists() 
        {
            return HitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
            if (HitPoints <= 0)
            {
                OnHpIsEmpty?.Invoke(gameObject);
            }
        }
    }
}