using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutDevCards : MonoBehaviour
{
    public static bool AboutDevCardIsOpen = false;
    
    public GameObject aboutCardUI;  
    public GameObject closeButton;

    // Update is called once per frame
    void Update()
    {
            if (AboutDevCardIsOpen)
            {
                AboutCard();
            }
            else
            {
                AboutCardClose();
            }
    }
    public void AboutCardClose()
    {
        aboutCardUI.SetActive(false);
        Time.timeScale = 1f;
        AboutDevCardIsOpen = false;
        closeButton.SetActive(true);
        
    }
    public void AboutCard()
    {
        aboutCardUI.SetActive(true);
        Time.timeScale = 0f;
        AboutDevCardIsOpen = true;
        closeButton.SetActive(false);
    }

}