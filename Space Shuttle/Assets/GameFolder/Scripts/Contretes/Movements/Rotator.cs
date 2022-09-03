using System.Collections;
using System.Collections.Generic;
using SpaceShuttle.Controllers;
using UnityEngine;

namespace SpaceShuttle.Movements
{
    public class Rotator
    {
        Rigidbody _rigidbody;
        PlayerController _playerController;

        public Rotator(PlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody = playerController.GetComponent<Rigidbody>();
        }

        public void FixedTick(Vector2 direction)
        {
            Vector3 currentPos = _playerController.transform.position;
            Vector3 newPos = new Vector3(direction.x, 0, direction.y);
            Vector3 positionLookAt = currentPos + newPos;
            
            _playerController.transform.LookAt(positionLookAt);
        }
    }
}
