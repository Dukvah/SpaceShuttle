using System.Collections;
using System.Collections.Generic;
using SpaceShuttle.Controllers;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceShuttle.Movements
{
    public class GunMover
    {
        PlayerController _playerController;
        GameObject _gun;
        Vector3 currentEulerAngles;

        public GunMover(PlayerController playerController)
        {
            _playerController = playerController; ;
            _gun = playerController.Radar;
        }

        public void FixedTick(Vector2 direction)
        {
            //_gun.transform.localRotation = Quaternion.Euler(direction.y * _playerController.GunRotationSpeed, _gun.transform.localRotation.y, direction.x * _playerController.GunRotationSpeed );
            currentEulerAngles += new Vector3(-direction.y,0f, direction.x) * Time.deltaTime * _playerController.GunRotationSpeed;
            currentEulerAngles.x = Mathf.Clamp(currentEulerAngles.x,-130f,-50f);
            currentEulerAngles.z = Mathf.Clamp(currentEulerAngles.z,-50f,50f);
            _gun.transform.rotation = Quaternion.Euler(currentEulerAngles);
            //_gun.transform.localRotation = Quaternion.Lerp(min,max, Time.deltaTime * _playerController.GunRotationSpeed);
            //new Vector3(direction.y,_gun.transform.rotation.y,direction.x)
        }
    }
}
