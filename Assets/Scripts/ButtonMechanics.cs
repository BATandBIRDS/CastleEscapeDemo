using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMechanics : MonoBehaviour
{//Subject

    Color32 pressedColor = new Color32(0, 255, 0, 255); // Green
    bool isPressed = false;
    public static event Action OnPressed;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Renderer>().material.color = pressedColor;
            isPressed = true;  
        }
    }

    void DoorOpener()
    {
        if (isPressed)
        {
            OnPressed?.Invoke();
        }
    }

    void Update()
    {
        DoorOpener();
    }
}
