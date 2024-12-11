using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class PauseMenu1 : MonoBehaviour
{
    //public GameObject ResumeButton;
    //public GameObject MainMenuButton;
    //public GameObject QuitButton;
    public GameObject Controller;
    public GameObject PausePanel;
    public RawButton toggleKey; // Ä¬ÈÏ°´¼üÎªEsc
    bool isPause = false;

    void Start()
    {
        //QuitButton.SetActive(false);
        //ResumeButton.SetActive(false);
        //MainMenuButton.SetActive(false);
        Controller.SetActive(false);
        PausePanel.SetActive(false);
    }
    public void ResumeEvent()
    {
        isPause = false;
        //QuitButton.SetActive(false);
        //ResumeButton.SetActive(false);
        //MainMenuButton.SetActive(false);
        PausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void QuitEvent()
    {
        Application.Quit();
    }
    void Update()
    {
        if (OVRInput.GetDown(toggleKey) && !isPause)

        {
            isPause = true;
            //QuitButton.SetActive(true);
            //ResumeButton.SetActive(true);
            //MainMenuButton.SetActive(true);
            Controller.SetActive(true);
            PausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        else if (OVRInput.GetDown(toggleKey) && isPause)
        { 
            ResumeEvent(); 
        } 
    }
}
   
  