using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField] GameObject _joystick;
    [SerializeField] Canvas _canvas;
    [SerializeField] RectTransform _canvasRT;
    [SerializeField] RectTransform _joyStickRT;
    [SerializeField] Camera _camera;
    
    private void Awake()
    {
        _joystick.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 anchoredPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRT,Input.mousePosition,_canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _camera, out anchoredPos);
            _joyStickRT.anchoredPosition = anchoredPos;
            
            _joystick.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _joystick.SetActive(false);
        }
        
        
    }
}
