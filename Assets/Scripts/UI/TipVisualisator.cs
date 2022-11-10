using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipVisualisator : MonoBehaviour
{
    private FloatingJoystick joystick;
    void Start()
    {
        joystick = FindObjectOfType<FloatingJoystick>();
    }

    
    void Update()
    {
        if (joystick.pointerDown)
        {
            gameObject.SetActive(false);
        }
    }
}
