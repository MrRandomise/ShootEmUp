using UnityEngine;

namespace ShootEmUp
{
    public class MoveCharacterController : MonoBehaviour, IListenerEnable, IListenerDisabled, IListenerFixUpdate
    {
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private CharacterController characterController;
        private Vector2 direction;

        public void OnListenerEnable()
        {
            characterController.inputControl.OnMoveAction += OnMove;
        }

        public void OnListenerDisabled()
        {
            characterController.inputControl.OnMoveAction -= OnMove;
        }

        private void OnMove(int dir)
        {
            var vector = new Vector3(dir, 0, 0) * Time.fixedDeltaTime;
            var postionCharacter = characterController.moveComponent.gameObject.transform.position;
            if (levelBounds.InBounds(vector + postionCharacter))
                direction = vector;
            else
                direction =  new Vector2(0f, 0f);
        }

        public void OnFixUpdate() {
            characterController.moveComponent.MoveByRigidbodyVelocity(direction);
        }

    }
}