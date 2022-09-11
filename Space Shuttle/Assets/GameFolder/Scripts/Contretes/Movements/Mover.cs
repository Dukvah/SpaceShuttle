using System.Collections;
using System.Collections.Generic;
using SpaceShuttle.Controllers;
using UnityEngine;

namespace SpaceShuttle.Movements
{
    public class Mover
    {
        PlayerController _playerController;
        GameObject _player;
        public Mover(PlayerController playerController)
        {
            _playerController = playerController; ;
            _player = playerController.gameObject;
        }

        public void FixedTick(bool isTouch)
        {
            if (isTouch)
            {
                _player.transform.position += _playerController.Speed * Time.deltaTime * _player.transform.forward;
                //_rigidbody.AddRelativeForce(Vector3.forward * Time.deltaTime * _playerController.Force);
            }
        }
    }
}
