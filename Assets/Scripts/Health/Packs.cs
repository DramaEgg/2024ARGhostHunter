using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Packs : MonoBehaviour
{
    public int HealthpackNum;
    public float timeLimit = 5f;
    public float currentTime;
    public GameObject[] HealthPack;
    public GameObject[] BackPack;
    public GameObject[] Key;
    public GameObject[] PressE;
    public Slider usingHPSlider;
    public Text usingHPCountDown;
    public TextMeshProUGUI HealthPackNumUI;
    public TextMeshProUGUI HealthNumUI;
    public float targetValue;
    public float currentHealth;
    public float maxHealth;
    public bool IsAddingHP = false;
    public bool isUsingHealthPack;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Healthpack();
        Backpack();
        if (PlayerInputHandler.Instance.GetPickupInput())
        {
            PressE[0].SetActive(false);
        }
    }

    public void Healthpack() 
    {
        HealthNumUI.text = "" + GetComponent<PlayerHealthControl>().CurrentHP.ToString("0");
    }
    public void Backpack()
    {
        HealthPackNumUI.text = "" + HealthpackNum;
        BackPack[2].gameObject.GetComponent<Text>().text = "" + HealthpackNum;
        if (PlayerInputHandler.Instance.GetBackPackInput())
        {

            if (BackPack[0].gameObject.activeSelf)
            {
                BackPack[0].SetActive(false);
            }
            else
            {
                BackPack[0].SetActive(true);
            }
        }
        if (HealthpackNum >= 1)
        {
            BackPack[1].SetActive(true);
        }
        else
            BackPack[1].SetActive(false);
        if (PlayerInputHandler.Instance.GetHealthPackInput() && HealthpackNum >= 1 && GetComponent<PlayerHealthControl>().CurrentHP < GetComponent<PlayerHealthControl>().OriginalHP && isUsingHealthPack == false)
        {
            currentTime = 5f;
            HealthpackNum -= 1;
            usingHPSlider.gameObject.SetActive(true);
            isUsingHealthPack = true;
            IsAddingHP = true;
            targetValue = this.gameObject.GetComponent<PlayerHealthControl>().CurrentHP + 10;
            //StartCoroutine(DecreaseHPOverTime());
        }
        else if(PlayerInputHandler.Instance.GetHealthPackInput() && HealthpackNum == 0)
        {
            
        }
        if (isUsingHealthPack == true)
        {

            if (currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
                usingHPCountDown.text = currentTime.ToString("0.0");
                usingHPSlider.value = currentTime / timeLimit;
                if (this.gameObject.GetComponent<PlayerHealthControl>().CurrentHP < targetValue - 0.01f && IsAddingHP == true)
                {
                    this.gameObject.GetComponent<PlayerHealthControl>().CurrentHP = Mathf.Lerp(this.gameObject.GetComponent<PlayerHealthControl>().CurrentHP, targetValue, Time.deltaTime);
                }
                else
                {
                    this.gameObject.GetComponent<PlayerHealthControl>().CurrentHP = targetValue;
                    IsAddingHP = false;
                }

                this.gameObject.GetComponent<PlayerHealthControl>().UpdateHp();

            }
            if (currentTime <= 0f)
            {
                //StopCoroutine(DecreaseHPOverTime());
                usingHPSlider.value = 1f;
                usingHPSlider.gameObject.SetActive(false);
                isUsingHealthPack = false;
                IsAddingHP = false;
                if(HealthpackNum == 0 && this.gameObject.GetComponent<PickupManager>().ContainItemType(SOItem.ItemType.HealthPack))
                {
                    this.gameObject.GetComponent<PickupManager>().RemoveItem(SOItem.ItemType.HealthPack);
                }
            }
        }
    }

    //private System.Collections.IEnumerator DecreaseHPOverTime()
    //{
    //    //while (currentTime > 0f)
    //    //{
    //    //    yield return new WaitForSeconds(1f);
    //    //    this.gameObject.GetComponent<HealthControl>().CurrentHP++;
    //    //    this.gameObject.GetComponent<HealthControl>().UpdateHp();
    //    //    currentTime--;
    //    //    if (currentTime <= 0f)
    //    //    {
    //    //        sliderComponent.value = 1f;
    //    //        sliderComponent.gameObject.SetActive(false);
    //    //        isUsingHealthPack = false;
    //    //    }
    //    //}
    //}

    public void AddHealthPack()
    {
        HealthPack[0].SetActive(true);
        HealthpackNum += 1;
    }

    public void AddKey()
    {
        Key[0].SetActive(true);
        Key[1].SetActive(true);
        //if(GetComponent<DoorTrigger>().doorOpened = true)
        //{
        //    Key[0].SetActive(false);
        //    Key[1].SetActive(false);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Supplies")
        {
            PressE[0].SetActive(true);
            if (PlayerInputHandler.Instance.GetPickupInput())
            {
                PressE[0].SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Supplies")
        {
            PressE[0].SetActive(false);
        }
    }

}
