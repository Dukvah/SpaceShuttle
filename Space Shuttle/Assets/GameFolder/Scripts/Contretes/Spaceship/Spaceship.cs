using System.Collections;
using SpaceShuttle.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Spaceship : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] GameObject _sitPostion, _radarZone;
    [SerializeField] PlayerController _playerController;

    Animator animator;
    NavMeshAgent navMeshAgent;
    RaycastHit hit;
    public bool CanFly { get; set; }
    public bool OnPlayer { get; set; }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        _radarZone.SetActive(false);
        
        CanFly = true;
        OnPlayer = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerController._uiManager.OnBoard(true);
            _playerController._breathable = true;
            OnPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerController._uiManager.OnBoard(false);
            _playerController._breathable = false;
            OnPlayer = false;
        }
    }

    public void OnBoard()
    {
        animator.SetBool("OpenDoor",true);
        _playerController.OnBoard(_sitPostion.transform.position);
        _radarZone.SetActive(false);
        OnPlayer = false;
        CanFly = true;

        _playerController.gameObject.transform.parent = this.gameObject.transform;
    }

    public void Launch()
    {
        CanFly = false;
        StartCoroutine(LaunchAsync());
    }

    private IEnumerator LaunchAsync()
    {
        yield return new WaitForSeconds(2f);
        _radarZone.SetActive(true);
    }
    
}
