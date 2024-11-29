using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public float rotationSpeed = 90.0f;
    public bool isRDOpen = true;

    private Quaternion fromRotation;
    private Quaternion toRotation;

    private Vector3 fromEuler;
    private Vector3 toEuler;

    private Vector3 rotationAxis;

    void Start()
    {
        rotationAxis = transform.TransformDirection(Vector3.up);
        fromRotation = GameObject.Find("RotateDoor").transform.rotation;
        fromRotation = transform.rotation;
        //fromEuler = fromRotation.eulerAngles;
        //toEuler = fromEuler + new Vector3(0,-90,0);
        //toRotation = Quaternion.Euler(toEuler);
        toRotation = transform.rotation * Quaternion.Euler(rotationAxis * 90f);
    }

    public void OpenDoor()
    {
        if (transform.rotation != toRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    public void CloseDoor()
    {
        if (transform.rotation != fromRotation)
        {            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, fromRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (isRDOpen == false)
        {
            CloseDoor();
        }
        else if (isRDOpen == true)
        {
            OpenDoor();
        }
        else { }
    }
}