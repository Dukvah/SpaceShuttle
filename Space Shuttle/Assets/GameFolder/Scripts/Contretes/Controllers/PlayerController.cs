using System;
using System.Collections;
using System.Collections.Generic;
using SpaceShuttle.Inputs;
using SpaceShuttle.Movements;
using UnityEngine;

namespace SpaceShuttle.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _turnSpeed;
        [SerializeField] float _force;

        Animator _animator;

        Mover _mover;
        Rotator _rotator;
        InputController _input;

        Vector2 _joystickDir;
        bool _canMove;
        bool _canForceForward;

        public float Force => _force;
        public float TurnSpeed => _turnSpeed;
        public bool canMove => _canMove;

        private void Awake()
        {
            _input = new InputController();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _canMove = true;
            
        }
        private void Update()
        {
            if (!_canMove) return;

            if (_input.IsForceForward)
            {
                _canForceForward = true;
                _animator.SetBool("isFly", true);
            }
            else
            {
                _canForceForward = false;
                _animator.SetBool("isFly", false);
            }

            _joystickDir = _input.JoystickDirection;
        }

        private void FixedUpdate()
        {
            if (_canForceForward)
            {
                Debug.Log("ssss");
                _mover.FixedTick(_canForceForward);
            }

            _rotator.FixedTick(_joystickDir);
        }
    }
}
