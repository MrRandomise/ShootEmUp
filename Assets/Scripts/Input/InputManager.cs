using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField] private GameObject character;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                character.GetComponent<PlayerAtackComponent>().Atack();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                character.GetComponent<MoveComponent>().Move(-1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                character.GetComponent<MoveComponent>().Move(1);
            }
            else
            {
                character.GetComponent<MoveComponent>().Move(0);
            }
        }
    }
}