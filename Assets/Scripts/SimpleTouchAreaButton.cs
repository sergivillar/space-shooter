using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SimpleTouchAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool touched;
    private int pointerID;
    private bool canFire;

    void Awake()
    {
        touched = false;
    }

    public void OnPointerDown(PointerEventData data)
    {
        // Set our start point
        if (!touched)
        {
            pointerID = data.pointerId;
            Debug.Log(pointerID);
            touched = true;
            canFire = true;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        // Reset everything
        if (data.pointerId == pointerID)
        {
            touched = false;
            canFire = false;
        }
    }
    
    public bool CanFire()
    {
        return canFire;
    }
}
