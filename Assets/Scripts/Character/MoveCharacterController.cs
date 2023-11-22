using UnityEngine;

namespace ShootEmUp
{
    public class MoveCharacterController : MonoBehaviour
    {
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private CharacterController characterController;
        private Vector2 direction;

        private void OnEnable()
        {
            characterController.inputControl.OnMoveAction += OnMove;
        }

        private void OnDisable()
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

        private void FixedUpdate() {
            characterController.moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}