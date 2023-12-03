using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputFireControl : MonoBehaviour, IListenerUpdate
    {
        public event Action OnFireAction;

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
