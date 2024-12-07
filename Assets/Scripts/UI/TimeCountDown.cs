using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCountDown : MonoBehaviour
{
    public TMP_Text timer;
    public SceneLoader CurrentSceneLoader;
    public GameObject ExitButton;
    public float maxTime;
    public float currentTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        maxTime = 10;
        StartCoroutine(CountDownEndButton());
    }

    void Update()
    {
        //CountDown();
    }
    
    public void CountDown()
    {
        currentTime = maxTime - Time.time;
        if (Time.time >= maxTime)
        {
            return;
        }
        timer.text = ((int)(maxTime - Time.time)).ToString();
        if (currentTime < 1)
        {
            ExitButton.SetActive(true);
        }
    }

    IEnumerator CountDownEndButton()
    {
        yield return new WaitForSeconds(maxTime);
        ExitButton.SetActive(true);
    }
}