using UnityEngine;
using System;

namespace ShootEmUp
{
    public class InputKeypboard : ControlInput, IListenerUpdate
    {        
        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFireInput();
            }

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
    }
}