using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{
    [SerializeField] GameObject _mine;
    [SerializeField] int _mineCount;
    
    private void Awake()
    {
        for (int i = 0; i < _mineCount; i++)
        {
            Instantiate(_mine,(Random.onUnitSphere * 8) + transform.position, Quaternion.identity, gameObject.transform);
        }
    }

    private void Update()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), 50f, RotateMode.FastBeyond360).SetRelative(true)
            .SetEase(Ease.Linear);
    }

    public void MineCreator()
    {
        StartCoroutine(MineCreatorAsync());
    }

    private IEnumerator MineCreatorAsync()
    {
        yield return new WaitForSeconds(60f);
        Instantiate(_mine,(Random.onUnitSphere * 8) + transform.position, Quaternion.identity, gameObject.transform);
    }
}
