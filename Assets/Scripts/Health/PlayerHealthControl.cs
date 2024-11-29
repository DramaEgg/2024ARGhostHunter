using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthControl : MonoBehaviour
{
    [Header("Settings")]
    public Image HPBarImage;
    public float CurrentHP;
    public float OriginalHP = 100f;
    public float ImageOriginalSize;
    public GameObject[] Gameover; 

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = OriginalHP;
        ImageOriginalSize = HPBarImage.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        //if (CurrentHP <= 0)
        //{
        //    Time.timeScale = 0;
        //    Gameover[0].SetActive (true);
        //}
    }

    public void UpdateHp()
    {
        if (CurrentHP <= 0)
        {
            Destroy(this.gameObject);
            if (this.gameObject.tag != "Player")
                Destroy(HPBarImage.transform.parent.gameObject);
        }

        float percentage = CurrentHP / OriginalHP;
        HPBarImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ImageOriginalSize * percentage);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        CurrentHP--;
    //    }
    //}
}
