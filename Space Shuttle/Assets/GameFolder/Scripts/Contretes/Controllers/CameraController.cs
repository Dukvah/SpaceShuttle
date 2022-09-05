using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _targetPlayer;
    [SerializeField] Vector3 _offset;
    [SerializeField] float _smoothSpeed = 0.125f;

    Vector3 spaceshipPos;
    Quaternion spaceshipRotation;
    
    public bool LookAstronaut { get; set; }
    public bool LookSpaceship { get; set; }

    private void Awake()
    {
        LookSpaceship = false;
        LookAstronaut = false;
        spaceshipRotation = transform.rotation;
        spaceshipPos = transform.position;
    }
    
    private void LateUpdate()
    {
        if (LookAstronaut)
        {
            Vector3 desiredPosition = _targetPlayer.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }

        if (LookSpaceship)
        {
            GoSpaceshipLook();
        }
    }

    void GoSpaceshipLook()
    {
        transform.DORotateQuaternion(spaceshipRotation, 2f);
        transform.DOMove(spaceshipPos, 3f).OnComplete(() =>  LookSpaceship = false);
    }
    
}
