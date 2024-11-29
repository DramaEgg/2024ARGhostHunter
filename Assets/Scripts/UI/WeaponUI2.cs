using scgFullBodyController;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUI2 : MonoBehaviour
{
    [Header("UI")]
    public GameObject[] Rifle;
    public GameObject[] Pistol;
    public int currentRifleAmmoNum;
    public int currentPistolAmmoNum;
    public int maxRifleAmmoNum;
    public int maxPistolAmmoNum;
    //public TextMeshProUGUI currentWeaponAmmoNumUI;
    //public TextMeshProUGUI currentPistolAmmoNumUI;
    //public TextMeshProUGUI maxRifleAmmoNumUI;
    //public TextMeshProUGUI maxPistolAmmoNumUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateIconUI();
    }
    public void updateIconUI()
    {
        //currentWeaponAmmoNumUI.text = "" + GetComponent<GunController>().bulletsInMag.ToString();
        if (PlayerInputHandler.Instance.GetFirstFireInput())
        {
            Rifle[0].SetActive(true);
            Rifle[1].SetActive(true);
            Pistol[0].SetActive(false);
            Pistol[1].SetActive(false);
        }
        else if (PlayerInputHandler.Instance.GetSecondFireInput())
        {
            Rifle[0].SetActive(false);
            Rifle[1].SetActive(false);
            Pistol[0].SetActive(true);
            Pistol[1].SetActive(true);
        }

    }

}
