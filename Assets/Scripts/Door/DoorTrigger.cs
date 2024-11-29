using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float rotationSpeed = 90.0f;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    private Vector3 rotationAxis;
    public PickupManager PickupManager;
    public GameObject[] PressF;
    public GameObject[] Key;
    public bool doorOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        rotationAxis = transform.TransformDirection(Vector3.up);
        fromRotation = GameObject.Find("KeyDoor").transform.rotation;
        fromRotation = transform.rotation;
        toRotation = transform.rotation * Quaternion.Euler(rotationAxis * -50.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpened) 
        {
            RemoveKey();
            //GetComponent<PickupManager>().isHoldingKey = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && other.GetComponent<PickupManager>().isHoldingKey && doorOpened == false) 
        {
            PressF[0].SetActive(true);
            if (PlayerInputHandler.Instance.GetDoorOpenInput())
            {
                OpenDoor();
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
    public void OpenDoor()
    {
        if (transform.rotation != toRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); 
        }
        if (transform.rotation == toRotation)
        {
            doorOpened = true;
        }

    }
    public void RemoveKey()
    {
        Key[0].SetActive(false);
        Key[1].SetActive(false);
    }

}
