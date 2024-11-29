using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour
{
    public PlayerHUD playerHUD;
    public Transform WeaponRoot;
    public SOWeapon[] SOWeapons;
    public GameObject[] Weapons;
    public int CurrentWeaponIndex = -1;
    public GameObject CurrentWeapon;
    public int TargetWeaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        InitializedWeaponInventory();
    }

    // Update is called once per frame
    void Update()
    {
        TargetWeaponIndex = PlayerInputHandler.Instance.GetSelectedWeaponInput() - 1;
        Debug.Log(TargetWeaponIndex);
        if (TargetWeaponIndex != -1)
        {
            CurrentWeaponIndex = ShowWeapon(TargetWeaponIndex);
        }
    }

    public void InitializedWeaponInventory()
    {
        SOWeapons = new SOWeapon[2];
        Weapons = new GameObject[2];
        CurrentWeaponIndex = -1;
    }

    public void AddWeapon(SOWeapon newWeapon)
    {
        int newWeaponIndex = (int)newWeapon.WeaponOrder;
        if (SOWeapons[newWeaponIndex] != null)
        {
            UnequipWeapon(SOWeapons[newWeaponIndex]);
            RemoveWeapon(newWeaponIndex);
        }
        SOWeapons[newWeaponIndex] = newWeapon;
        playerHUD.UpdateWeaponIconInfo(newWeapon);
        EquipWeapon(newWeapon);
        CurrentWeaponIndex = ShowWeapon(newWeaponIndex);
    }

    public void RemoveWeapon(int WeaponIndex)
    {
        SOWeapons[WeaponIndex] = null;
    }

    public void EquipWeapon(SOWeapon InputSOWeapon)
    {
        int CurrentWeaponOrder = (int)InputSOWeapon.WeaponOrder;
        if (Weapons[CurrentWeaponOrder] != null)
        {
            return;
        }
        CurrentWeapon = Instantiate(InputSOWeapon.WeaponPrefab, WeaponRoot);
        Weapons[CurrentWeaponOrder] = CurrentWeapon;
        Weapons[CurrentWeaponOrder].SetActive(false);
        Weapons[CurrentWeaponOrder].GetComponent<WeaponSway>().IsSelected = true;
    }

    public void UnequipWeapon(SOWeapon InputSOWeapon)
    {
        Weapons[(int)InputSOWeapon.WeaponOrder] = null;
    }

    public int ShowWeapon(int WeaponIndex)
    {
        if (Weapons[WeaponIndex] == null)
        {
            return CurrentWeaponIndex;
        }
        for (int i = 0; i < Weapons.Length; i++)
        {
            if (Weapons[i] != null)
            {
                if (i == WeaponIndex)
                {
                    Weapons[i].SetActive(true);
                    Weapons[i].GetComponent<WeaponSway>().IsSelected = true;
                    CurrentWeapon = Weapons[i];
                    playerHUD.UpdateWeaponInfo(SOWeapons[i]);
                }
                else
                {
                    Weapons[i].GetComponent<WeaponSway>().IsSelected = false;
                }
            }
        }
        return WeaponIndex;
    }


}
