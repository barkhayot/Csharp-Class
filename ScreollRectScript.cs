using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreollRectScript : MonoBehaviour
{
    private ScrollRect scrollRect;
    private bool mouseDown, buttonDown, buttonUp;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown)
        {
            if (buttonDown)
            {
                ScrollDown ();
            }
            else if (buttonUp)
            {
                ScrollUp ();
            }
        }
    }
    
    public void ButtonDownIsPressed()
    {
        mouseDown = true;
        buttonDown = true;
    }
    
    public void ButtonUpIsPressed()
    {
        mouseDown = true;
        buttonUp = true;
    }

    private ScrollDown()
    {
        if (Input.GetMouseButtonUp (0))
        {
            mouseDown = false;
            buttonDown = false;
        }
        else{
            scrollRect.horizontalNormalizedPosition -= 0.01f;
        }
    }

    private void ScrollUp()
    {
        if (Input.GetMouseButtonUp (0))
        {
            mouseDown = false;
            buttonUp = false;
        }
        else
        {
            scrollRect.horizontalNormalizedPosition += 0.01f;
        }
    }
}
