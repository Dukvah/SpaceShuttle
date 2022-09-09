using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryBar : MonoBehaviour
{
    [SerializeField] Image _slider;

    private void Awake()
    {
        ResetProgress();
    }
    

    public void ResetProgress()
    {
        _slider.fillAmount = 0f;
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
