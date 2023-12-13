using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveCharacterControl : IListenerEnabled, IListenerDisabled, IListenerFixUpdate
    {
        private LevelBounds levelBounds;

        private InputMoveControl moveControl;

        private MoveComponent moveComponent;

        private Transform transform;

        private Vector2 direction;

        public MoveCharacterControl(LevelBounds bounds, InputMoveControl moveCont, ServiceCharacter serviceCharacter)
        {
            levelBounds = bounds;
            moveControl = moveCont;
            transform = serviceCharacter.Character.transform;
            moveComponent = serviceCharacter.CharacterMoveComponent;
            ListenerManager.Listeners.Add(this);
        }

        public void ListenerEnabled()
        {
            moveControl.OnMoveAction += OnMove;
        }

        public void ListenerDisabled()
        {
            moveControl.OnMoveAction -= OnMove;
        }

        private void OnMove(int dir)
        {
            var vector = new Vector3(dir, 0, 0) * Time.fixedDeltaTime;
            var positionCharacter = transform.position;
            if (levelBounds.InBounds(vector + positionCharacter))
                direction = vector;
            else
                direction =  new Vector2(0f, 0f);
        }

        public void OnFixUpdate(float deltaTime) 
        {
            moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}