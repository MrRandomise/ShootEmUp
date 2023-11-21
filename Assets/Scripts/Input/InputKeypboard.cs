using UnityEngine;
using System;

namespace ShootEmUp
{
    public class InputKeypboard : MonoBehaviour
    {        
        public event Action OnFireAction;
        public event Action<int> OnMoveAction;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireAction?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnMoveAction?.Invoke(-1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                OnMoveAction?.Invoke(1);
            }
            else
            {
                OnMoveAction?.Invoke(0);
            }
        }
    }
}