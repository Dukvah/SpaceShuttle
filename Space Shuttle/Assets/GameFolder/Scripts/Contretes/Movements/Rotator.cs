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

        public void FixedTick(Quaternion direction)
        {
            // if (direction == new Vector2(0,0))
            // {
            //     if (_rigidbody.freezeRotation) _rigidbody.freezeRotation = false;
            //     
            //     return;
            // }
            //
            // if (!_rigidbody.freezeRotation) _rigidbody.freezeRotation = true;
            
            _playerController.transform.rotation = Quaternion.RotateTowards(_playerController.transform.rotation, ,Vector3.up * _playerController.TurnSpeed * Time.deltaTime);
        }

        Quaternion CalculateRotation()
        {
            Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
            return temp;
        }

        Vector3 CalculateDirection()
        {
            Vector3 temp = ()
        }
    }
}
