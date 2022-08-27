using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

namespace SpaceShuttle.Inputs
{
    public class InputController
    {
        DefaultAction _input;

        public bool IsForceForward { get; private set; }
        public Vector2 JoystickDirection { get; private set; }


        public InputController()
        {
            _input = new DefaultAction();
            
            _input.Astronaut.Move.performed += context =>
            {
                JoystickDirection = context.ReadValue<Vector2>();
                IsForceForward = JoystickDirection.x != 0 || JoystickDirection.y != 0;
            };
            _input.Astronaut.Move.canceled += context =>
            {
                IsForceForward = false;
            };
            
            
            _input.Enable();
        }
    }
}

