using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spaceship : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layerMask;

    private NavMeshAgent navMeshAgent;
    RaycastHit hit;

    public Vector3 Destination { get; set; }
    public bool CanFly { get; set; }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        CanFly = true;
    }


    private void Update()
    {
        if (!CanFly) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out  hit, float.MaxValue, layerMask))
            {
                navMeshAgent.destination = hit.point;
            }
        }
    }
}
