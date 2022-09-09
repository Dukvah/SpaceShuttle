using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Image _slider;
    [SerializeField] Canvas _canvas;

    private void Awake()
    {
        ResetProgress();
        
    }

    private void Update()
    {
        _canvas.transform.LookAt(Camera.main.transform);
        _canvas.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);   
    }

    public void ResetProgress()
    {
        _slider.fillAmount = 0f;
        _canvas.gameObject.SetActive(false);
    }

    public void SetPositionBar()
    {
        _canvas.gameObject.SetActive(true);
    }
    
    public bool IncreaseProgress(float increase)
    {
        _slider.fillAmount += increase;

        if (_slider.fillAmount >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
