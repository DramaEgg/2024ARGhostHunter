using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCorridorRight : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public bool isRotated = true;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    private Vector3 rotationAxis;

    void Start()
    {
        rotationAxis = transform.TransformDirection(Vector3.back);
        fromRotation = GameObject.Find("RightCorridor").transform.rotation;
        fromRotation = transform.rotation;
        toRotation = transform.rotation * Quaternion.Euler(rotationAxis * -15.0f);
        isRotated = true;
    }

    void Update()
    {
        if (transform.rotation == toRotation)
        {
            isRotated = false;
        }
        if (transform.rotation == fromRotation)
        {
            isRotated = true;
        }
        if (isRotated == false)
        {
            RotateBack();
        }
        else if (isRotated == true)
        {
            StartRotation();
        }
        else { }
    }
    public void StartRotation()
    {
        if (transform.rotation != toRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    public void RotateBack()
    {
        if (transform.rotation != fromRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, fromRotation, rotationSpeed * Time.deltaTime);
        }
    }
}