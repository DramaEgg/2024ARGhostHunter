using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject ResumeButton;
    public GameObject MainMenuButton;
    public GameObject QuitButton;
    bool isPause = false;

    void Start()
    {
        QuitButton.SetActive(false);
        ResumeButton.SetActive(false);
        MainMenuButton.SetActive(false);
    }
    public void ResumeEvent()
    {
        isPause = false;
        QuitButton.SetActive(false);
        ResumeButton.SetActive(false);
        MainMenuButton.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void QuitEvent()
    {
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)

        {
            isPause = true;
            QuitButton.SetActive(true);
            ResumeButton.SetActive(true);
            MainMenuButton.SetActive(true);
            Time.timeScale = 0.0f;
        }

        else if (Input.GetKeyDown(KeyCode.Escape)&& isPause)
        { 
            ResumeEvent(); 
        } 
    }
}
   
  