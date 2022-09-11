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
        public bool IsMining { get; set; }
        public Vector2 MoveJoystickDirection { get; private set; }
        public Vector2 GunJoystickDirection { get; private set; }



        public InputController()
        {
            _input = new DefaultAction();
            
            _input.Astronaut.Move.performed += context =>
            {
                MoveJoystickDirection = context.ReadValue<Vector2>();
                IsForceForward = MoveJoystickDirection.x != 0 || MoveJoystickDirection.y != 0;
            };
            _input.Astronaut.Move.canceled += context =>
            {
                IsForceForward = false;
            };
            
            _input.Astronaut.Gun.performed += context =>
            {
                GunJoystickDirection = context.ReadValue<Vector2>();
                IsMining = GunJoystickDirection.x != 0 || GunJoystickDirection.y != 0;
            };
            _input.Astronaut.Gun.canceled += context =>
            {
                IsMining = false;
            };
            
            
            _input.Enable();
        }
    }
}

