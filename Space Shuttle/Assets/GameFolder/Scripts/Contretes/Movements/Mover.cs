using System.Collections;
using System.Collections.Generic;
using SpaceShuttle.Controllers;
using UnityEngine;

namespace SpaceShuttle.Movements
{
    public class Mover
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;

        public Mover(PlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick(bool isTouch)
        {
            if (isTouch)
            {
                _rigidbody.AddRelativeForce(Vector3.right * Time.deltaTime * _playerController.Force);
            }
        }
    }
}
