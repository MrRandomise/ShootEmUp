using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputFireControl : MonoBehaviour
    {
        public event Action OnFireAction;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireInput();
            }
        }

        public void OnFireInput()
        {
            OnFireAction?.Invoke();
        }
    }
}
