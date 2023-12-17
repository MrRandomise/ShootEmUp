using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgentComponent : MonoBehaviour
    {
        [NonSerialized] public GameObject Target = null;

        public WeaponComponent WeaponComponent;

        public EnemyMoveAgentComponent MoveAgent;

        public BulletConfig BulletConfig;

        public float Countdown = 1;

        public float CurrentTime;

        public EnemyAttackAgentLogick EnemyAttack;

        [Inject]
        private void Construct(ListenerManager listener, BulletSystem bullet)
        {
            EnemyAttack = new EnemyAttackAgentLogick(this, listener, bullet);
        }
    }
}