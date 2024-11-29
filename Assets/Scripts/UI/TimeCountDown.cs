using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCountDown : MonoBehaviour
{
    public TMP_Text timer;
    public int maxTime;

    void Start()
    {
        maxTime = 120;
    }

    void Update()
    {
        if (Time.time >= maxTime)
        {
            return;
        }
        timer.text = ((int)(maxTime - Time.time)).ToString();
    }
}