using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputMoveControl : IListenerUpdate
    {
        public event Action<int> OnMoveAction;

        public InputMoveControl()
        {
            ListenerManager.Listeners.Add(this);
        }

        public void OnUpdate(float deltaTime)
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
