using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class DoorTrigger2 : MonoBehaviour
{
    public RotateDoor2 Door;
    public GameObject[] PressF;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Door.doorType != RotateDoor2.DoorType.EndGameMainDoor
                && (other.gameObject.GetComponent<PickupManager>().ContainsKey(Door.NeedKeyType) == true
                || Door.NeedKeyType == DoorKey.KeyType.None))
            {
                Door.IsDoorOutside = true;
            }
            else
            {

            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && other.GetComponent<PickupManager>().isHoldingKey)
        {
            PressF[0].SetActive(true);
            if (PlayerInputHandler.Instance.GetDoorOpenInput())
            {
                PressF[0].SetActive(false);
            }
        }
        else
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PressF[0].SetActive(false);
        }
    }
}
