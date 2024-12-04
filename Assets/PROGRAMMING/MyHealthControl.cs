using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHealthControl : MonoBehaviour
{
    [Header("Settings")]
    public Image HPBarImage;
    public float CurrentHP;
    public float OriginalHP = 100f;
    public float ImageOriginalSize;
    public GameObject Gameover;
    public GameObject GameoverAudio;
    public SceneLoader CurrentSceneLoader;

    void Start()
    {
        CurrentHP = OriginalHP;
        ImageOriginalSize = HPBarImage.rectTransform.rect.width;
        //CurrentSceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP < OriginalHP)
        {
            CurrentHP++.ToString();
        }

        if (CurrentHP <= 0)
        {
            GameoverAudio.SetActive(true);
        }
    }

    public void UpdateHp()
    {
        if (CurrentHP <= 0)
        {
            Gameover.SetActive(true);
            StartCoroutine(loadDeadScene());
        }
        float percentage = CurrentHP / OriginalHP;
        HPBarImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ImageOriginalSize * percentage);
    }

    IEnumerator loadDeadScene()
    {
        Time.timeScale = 0.0f;
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(2);
        //CurrentSceneLoader.LoadNextScene();
    }
}