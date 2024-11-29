using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image PrimaryWeaponImage;
    public Image SecondaryWeaponImage;
    public TMP_Text WeaponName;
    public TMP_Text AmmoNum;
    public TMP_Text AmmoMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWeaponInfo(int WeaponOrder, Sprite inputImage, string inputName, int inputAmmoNum, int inputAmmoMax)
    {
        if(WeaponOrder == 0)
            PrimaryWeaponImage.sprite = inputImage;
        else if(WeaponOrder == 1)
            SecondaryWeaponImage.sprite = inputImage;
        WeaponName.text = inputName;
        AmmoNum.text = inputAmmoNum.ToString();
        AmmoMax.text = inputAmmoMax.ToString();
    }

    public void UpdateWeaponInfo( string inputName, int inputAmmoNum, int inputAmmoMax)
    {
        WeaponName.text = inputName;
        AmmoNum.text = inputAmmoNum.ToString();
        AmmoMax.text = inputAmmoMax.ToString();
    }
}
