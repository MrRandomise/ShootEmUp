using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputMoveControl : MonoBehaviour
    {
        public event Action<int> OnMoveAction;

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnMoveInput(-1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                OnMoveInput(1);
            }
            else
            {
                OnMoveInput(0);
            }
        }

        private void OnMoveInput(int dir)
        {
            OnMoveAction?.Invoke(dir);
        }
    }
}
