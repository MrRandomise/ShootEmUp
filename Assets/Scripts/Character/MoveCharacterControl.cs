using UnityEngine;
using UnityEngine.EventSystems;

namespace ShootEmUp
{
    public sealed class MoveCharacterControl : MonoBehaviour, Listeners.IListenerStart, Listeners.IListenerStop, Listeners.IListenerFixUpdate
    {
        [SerializeField] private LevelBounds levelBounds;

        [SerializeField] private InputMoveControl moveControl;

        [SerializeField] private MoveComponent moveComponent;

        private Vector2 direction;

        public void OnStart()
        {
            moveControl.OnMoveAction += OnMove;
        }

        public void OnStop()
        {
            moveControl.OnMoveAction -= OnMove;
        }

        private void OnMove(int dir)
        {
            var vector = new Vector3(dir, 0, 0) * Time.fixedDeltaTime;
            var postionCharacter = moveComponent.gameObject.transform.position;
            if (levelBounds.InBounds(vector + postionCharacter))
                direction = vector;
            else
                direction =  new Vector2(0f, 0f);
        }

        public void OnFixUpdate() 
        {
            moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}