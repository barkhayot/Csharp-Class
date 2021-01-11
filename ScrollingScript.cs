using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrollingScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private ScrollRectScript scrollRectScript;
    [SerializeField]
    private bool isDownButton;
   public void OnPointerDown (PointerEventData eventData)
   {
       if (isDownButton)
       {
           scrollRectScript.ButtonDownIsPressed();
       }
       else
       {
           scrollRectScript.ButtonUpIsPressed();
       }
   }
}
