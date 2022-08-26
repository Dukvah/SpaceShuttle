using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

namespace SpaceShuttle.Inputs
{
    public class InputController
    {
        DefaultAction _input;

        public bool IsForceForward { get; set; }
        public Quaternion JoystickDirection { get; set; }

        public InputController()
        {
            _input = new DefaultAction();
            
            _input.Astronaut.Move.performed += context =>
            {
                JoystickDirection =  context.ReadValue<Quaternion>();
                
                IsForceForward = true;
                // if (context.ReadValue<Vector2>() != new Vector2(0,0))
                // {
                //     IsForceForward = true;
                // }
            };

            _input.Enable();
        }
    }
}

