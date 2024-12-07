using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCdown : MonoBehaviour
{
    public bool isPause = false;
    public GameObject PauseMenu;
    public GameObject[] Info;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {

            PauseMenu.SetActive(true);
            Info[0].SetActive(false);
            Info[1].SetActive(false);
            isPause = true;
            
            Time.timeScale = 0.0f;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            Time.timeScale = 1.0f;
            isPause = false;
            PauseMenu.SetActive(false);
            Info[0].SetActive(true);
            Info[1].SetActive(true);
        }
        if (PauseMenu.activeInHierarchy == false)
        {
            isPause = false;
        }
        if (isPause)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
