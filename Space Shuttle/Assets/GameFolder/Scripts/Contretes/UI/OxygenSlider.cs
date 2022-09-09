using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenSlider : MonoBehaviour
{
    Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        
        _slider.value = _slider.maxValue;
    }
    
    public bool DecreaseProgress(float decrease)
    {
        _slider.value -= decrease;

        if (_slider.value <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
