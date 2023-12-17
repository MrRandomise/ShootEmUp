using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgentComponent : MonoBehaviour
    {
        public bool IsReached = false;

        public float Magnitude = 0.25f;

        public MoveComponent MoveComponent;

        public Vector2 Destination;

        public EnemyMoveAgentLogick EnemyMove;


        [Inject]
        private void Construct(ListenerManager listener)
        {
            EnemyMove = new EnemyMoveAgentLogick(this, listener);
        }
    }
}