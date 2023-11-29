using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShootEmUp
{
    public sealed class InputMoveControl : MonoBehaviour, Listeners.IListenerUpdate
    {
        public event Action<int> OnMoveAction;

        public void OnUpdate()
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
