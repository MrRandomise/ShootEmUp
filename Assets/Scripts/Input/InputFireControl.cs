using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputFireControl : MonoBehaviour, Listeners.IListenerUpdate
    {
        public event Action OnFireAction;

        public void OnUpdate()
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
