using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spaceship : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] GameObject _radarZone;

    Animator animator;
    EntryBar entryBar;
    NavMeshAgent navMeshAgent;
    RaycastHit hit;
    public bool CanFly { get; set; }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        entryBar = GetComponent<EntryBar>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        CanFly = true;
    }


    private void Update()
    {
        if (!CanFly) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out  hit, float.MaxValue, _layerMask))
            {
                navMeshAgent.destination = hit.point;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (entryBar.IncreaseProgress(0.005f))
            {
                animator.SetBool("OpenDoor",true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            entryBar.ResetProgress();
        }
    }
}
