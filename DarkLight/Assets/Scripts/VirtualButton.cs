using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class VirtualButton : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image buttonImage;
    public bool isPressed;

    public void OnStart()
    {
        isPressed = false;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        OnPointerDown(ped);
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