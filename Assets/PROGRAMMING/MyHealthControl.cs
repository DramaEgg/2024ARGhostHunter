using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHealthControl : MonoBehaviour
{
    [Header("Settings")]
    //public Image HPBarImage;
    public float CurrentHP;
    public float MaxHP = 100f;
    public float AddHPAmount = 0.05f;
    public GameObject LowHPFilter;

    //public GameObject Gameover;
    //public GameObject GameoverAudio;
    //public SceneLoader CurrentSceneLoader;
    //public float ImageOriginalSize; //HealthBar

    void Start()
    {
        CurrentHP = MaxHP;
        //ImageOriginalSize = HPBarImage.rectTransform.rect.width;
        //CurrentSceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP < MaxHP)
        {
            StartCoroutine(AddHP());
        }
        if (CurrentHP < 30)
        {
            LowHPFilter.SetActive(true);
        }        
        if (CurrentHP > 30)
        {
            LowHPFilter.SetActive(false);
        }

        //if (CurrentHP <= 0)
        //{
        //    GameoverAudio.SetActive(true);
        //}
    }

    public void UpdateHp()
    {
        if (CurrentHP <= 0)
        {
            //Gameover.SetActive(true);
            StartCoroutine(loadDeadScene());
        }
        //float percentage = CurrentHP / MaxHP;
        //HPBarImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ImageOriginalSize * percentage);
    }

    IEnumerator AddHP()
    {
        CurrentHP = Mathf.Min(CurrentHP + AddHPAmount,MaxHP);
        yield return new WaitForSeconds(2);
    }
    IEnumerator loadDeadScene()
    {
        Time.timeScale = 0.0f;
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(2);
        //CurrentSceneLoader.LoadNextScene();
    }
}