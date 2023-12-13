using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputFireControl : IListenerUpdate
    {
        public event Action OnFireAction;

        public InputFireControl()
        {
            ListenerManager.Listeners.Add(this);
        }

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireInput();
            }
        }

        private void OnFireInput()
        {
            OnFireAction?.Invoke();
        }
    }
}
