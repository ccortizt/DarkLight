using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{


    void Start()
    {

    }

    public void Show1()
    {
        GameObject.FindGameObjectWithTag("Menu1").gameObject.transform.SetSiblingIndex(4);
        //GameObject.FindGameObjectWithTag("Menu2").gameObject.transform.SetSiblingIndex(3);
        //GameObject.FindGameObjectWithTag("Menu3").gameObject.transform.SetSiblingIndex(2);
        //GameObject.FindGameObjectWithTag("Menu4").gameObject.transform.SetSiblingIndex(1);
    }
    public void Show2()
    {
        //GameObject.FindGameObjectWithTag("Menu1").gameObject.transform.SetSiblingIndex(1);
        GameObject.FindGameObjectWithTag("Menu2").gameObject.transform.SetSiblingIndex(4);
        //GameObject.FindGameObjectWithTag("Menu3").gameObject.transform.SetSiblingIndex(3);
        //GameObject.FindGameObjectWithTag("Menu4").gameObject.transform.SetSiblingIndex(2);
    }

    public void Show3()
    {
    //    GameObject.FindGameObjectWithTag("Menu1").gameObject.transform.SetSiblingIndex(2);
    //    GameObject.FindGameObjectWithTag("Menu2").gameObject.transform.SetSiblingIndex(1);
        GameObject.FindGameObjectWithTag("Menu3").gameObject.transform.SetSiblingIndex(4);
        //GameObject.FindGameObjectWithTag("Menu4").gameObject.transform.SetSiblingIndex(3);
    }
    public void Show4()
    {
        //GameObject.FindGameObjectWithTag("Menu1").gameObject.transform.SetSiblingIndex(3);
        //GameObject.FindGameObjectWithTag("Menu2").gameObject.transform.SetSiblingIndex(2);
        //GameObject.FindGameObjectWithTag("Menu3").gameObject.transform.SetSiblingIndex(1);
        GameObject.FindGameObjectWithTag("Menu4").gameObject.transform.SetSiblingIndex(4);
    }


}
