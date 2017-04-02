using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class VirtualButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Image buttonImage;
    public bool isPressed;


    public void Start()
    {
        isPressed = false;       
    }

    public void ButtonOff()
    {
        isPressed = false;
    }

    public void OnStart()
    {
        isPressed = false;
        
    }   

    public virtual void OnPointerDown(PointerEventData ped)
    {
        //GameObject.FindGameObjectWithTag("Message").GetComponent<Text>().text = "pressed" + gameObject.name;
        isPressed = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        isPressed = false;
    }
}