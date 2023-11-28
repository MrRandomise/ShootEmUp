using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveCharacterControl : MonoBehaviour
    {
        [SerializeField] private LevelBounds levelBounds;

        [SerializeField] private InputMoveControl moveControl;

        [SerializeField] private MoveComponent moveComponent;

        private Vector2 direction;

        private void OnEnable()
        {
            moveControl.OnMoveAction += OnMove;
        }

        private void OnDisable()
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

        private void FixedUpdate() 
        {
            moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}