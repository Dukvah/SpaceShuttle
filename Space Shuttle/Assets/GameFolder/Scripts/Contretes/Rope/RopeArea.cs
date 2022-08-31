using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeArea : MonoBehaviour
{
    [SerializeField] Transform _characterTransform;
    [SerializeField] SphereCollider _sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        _sphereCollider.center = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        _sphereCollider.radius = 20;

        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 betweenVector = _cubeTransform.position - _characterTransform.position;
        //float distance = Vector3.Distance(gameObject.transform.position, _characterTransform.position);
    }
}
