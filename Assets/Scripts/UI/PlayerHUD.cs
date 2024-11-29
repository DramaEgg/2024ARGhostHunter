using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public WeaponUI weaponUIInfo;
    public Image keySprite;
    public Image keyBackpackSprite;

    //public MiniMapCtrl MiniMapCtrl;
    //public HealthControl HealthControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWeaponIconInfo(SOWeapon InputSOWeapon)
    {
        weaponUIInfo.UpdateWeaponInfo((int)InputSOWeapon.WeaponOrder, InputSOWeapon.Icon, InputSOWeapon.ItemName, InputSOWeapon.AmmoNum, InputSOWeapon.AmmoMax);
    }
    public void UpdateWeaponInfo(SOWeapon InputSOWeapon)
    {
        weaponUIInfo.UpdateWeaponInfo(InputSOWeapon.ItemName, InputSOWeapon.AmmoNum, InputSOWeapon.AmmoMax);
    }
    public void UpdateSpriteColor(Color InputColor)
    {
        keySprite.color = InputColor;
        keyBackpackSprite.color = InputColor;
    }
}
