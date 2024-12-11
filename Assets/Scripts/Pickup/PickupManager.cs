using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public float PickupRange = 6.0f;
    public Vector3 ScreenPoint;
    public LayerMask CurrentMask;
    public Ray PickupRay;
    public RaycastHit hitInfo;
    //public List<SOWeapon> SOWeapons;
    public List<SOItem> SOItems;
    //public PlayerHUD playerHUD;
    public bool isHoldingKey = false;
    public GameObject[] KeyUI;
    public GameObject[] PressF;

    public WeaponInventory weaponInventory;
    public Packs Packs;
    //public Key Key;
    //public DoorTrigger DoorTrigger;

    //[Header("Door Related (new)")]
    //public RotateDoor2 CurrentDoor;
    //public List<DoorKey.KeyType> KeyList = new List<DoorKey.KeyType>();

    // Start is called before the first frame update
    void Start()
    {
        //SOWeapons = new List<SOWeapon>();
        SOItems = new List<SOItem>();
        CurrentMask = LayerMask.GetMask("PickupItem");
        ScreenPoint = new Vector3(Screen.width / 2, Screen.height / 2);  
    }

    // Update is called once per frame
    void Update()
    {
        PickupRay = Camera.main.ScreenPointToRay(ScreenPoint);
        Debug.DrawRay(PickupRay.origin, PickupRay.direction * PickupRange, Color.blue);
        PickupItem(CurrentMask);
        
        //if (PlayerInputHandler.Instance.GetDoorOpenInput())
        //{
        //    if (Physics.Raycast(PickupRay, out hitInfo, PickupRange))
        //    {
        //        if(hitInfo.collider.gameObject.tag == "Door")
        //        {
        //            CurrentDoor = hitInfo.collider.gameObject.GetComponent<RotateDoor2>();
        //            if (ContainsKey(CurrentDoor.NeedKeyType) == true || CurrentDoor.NeedKeyType == DoorKey.KeyType.None)
        //            {
        //                if (CurrentDoor.openState == RotateDoor2.OpenState.Close)
        //                {
        //                    if (CurrentDoor.IsDoorOutside)
        //                    {
        //                        CurrentDoor.openState = RotateDoor2.OpenState.OpenIn;
        //                        CurrentDoor.IsDoorOpen = true;
        //                    }
        //                    else
        //                    {
        //                        CurrentDoor.openState = RotateDoor2.OpenState.OpenOut;
        //                        CurrentDoor.IsDoorOpen = true;
        //                    }
        //                    //CurrentDoor.PlayDoorAudio();
        //                    RemoveKey(CurrentDoor.NeedKeyType);
        //                    isHoldingKey = false;
        //                }
        //                else
        //                {
        //                    CurrentDoor.openState = RotateDoor2.OpenState.Close;
        //                    CurrentDoor.IsDoorOpen = false;
        //                    //CurrentDoor.PlayDoorAudio();
        //                }
        //            }
        //        }

        //    }

        //}
    }

    public void PickupItem(LayerMask inputLayer)
    {
        if(PlayerInputHandler.Instance.GetPickupInput())
        {
            if (Physics.Raycast(PickupRay, out hitInfo, PickupRange, inputLayer))
            {
                SOItem tempItem = hitInfo.collider.gameObject.GetComponent<PickupObject>().item;
                if(tempItem == null)
                {
                    return;
                }
                switch (tempItem.Type)
                {
                    case SOItem.ItemType.Weapon:
                        //SOWeapons.Add(tempItem as SOWeapon);
                        weaponInventory.AddWeapon(tempItem as SOWeapon);
                        //playerHUD.UpdateWeaponInfo(tempItem.Icon, tempItem.ItemName, (tempItem as SOWeapon).AmmoNum, (tempItem as SOWeapon).AmmoMax);
                        Destroy(hitInfo.collider.gameObject);
                        break;
                    //case SOItem.ItemType.Key:
                    //    //if (!SOItems.Contains(tempItem))
                    //    //{
                    //    //    SOItems.Add(tempItem);
                    //    //}
                    //    //Debug.Log("Player got a key and the name is: " + tempItem.ItemName);
                    //    isHoldingKey = true;
                    //    //Packs.AddKey();
                    //    AddKey(hitInfo.collider.gameObject.GetComponent<DoorKey>().DoorKeyType);
                    //    GetComponent<PlayerHUD>().UpdateSpriteColor(hitInfo.collider.gameObject.GetComponent<DoorKey>().KeyColor);
                    //    Destroy(hitInfo.collider.gameObject);
                    //    break;
                    case SOItem.ItemType.HealthPack:
                        if(!SOItems.Contains(tempItem))
                        {
                            SOItems.Add(tempItem);
                        }
                        Packs.Backpack();
                        Packs.AddHealthPack();
                        Destroy(hitInfo.collider.gameObject);
                        break;
                }
            }
        }

    }

    public void RemoveItem(SOItem.ItemType itemType)
    {
        SOItem tempItem = null;
        foreach (var item in SOItems)
        {
            if(item.Type == itemType)
            {
                tempItem = item;
            }
        }
        SOItems.Remove(tempItem);
    }

    public bool ContainItemType(SOItem.ItemType itemType)
    {
        foreach (var item in SOItems)
        {
            if (item.Type == itemType)
            {
                return true;
            }
        }
        return false;
    }

    //public void AddKey(DoorKey.KeyType inputKey)
    //{
    //    KeyList.Add(inputKey);
    //    KeyUI[0].SetActive(true);
    //    KeyUI[1].SetActive(true);
    //}

    //public void RemoveKey(DoorKey.KeyType inputKey)
    //{
    //    KeyList.Remove(inputKey);
    //    KeyUI[0].SetActive(false);
    //    KeyUI[1].SetActive(false);
    //}

    //public bool ContainsKey(DoorKey.KeyType inputKey)
    //{
    //    return KeyList.Contains(inputKey);
    //}

}
