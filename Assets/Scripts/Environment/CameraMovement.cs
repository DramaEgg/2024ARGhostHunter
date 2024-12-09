using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    private Vector3 rotationAxis;
    public float rotationSpeed = 10.0f;
    public float Movespeed = 0.8f;
    public bool isMoved = false;
    public bool isRotated = true;

    void Start()
    {
        startPosition = GameObject.Find("Main Camera").transform.position;
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0, 0, 20);
        rotationAxis = transform.TransformDirection(Vector3.up);
        fromRotation = GameObject.Find("Main Camera").transform.rotation;
        fromRotation = transform.rotation;
        toRotation = transform.rotation * Quaternion.Euler(rotationAxis * 60.0f);
        isMoved = true;
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
        if (transform.position == endPosition)
        {
            isMoved = true;
        }
        if (transform.position == startPosition)
        {
            isMoved = false;
        }
        if (isMoved == false)
        {
            MoveForward();
        }
        else if (isMoved == true)
        {
            MoveBackward();
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

    public void MoveForward()
    {
        if (transform.position != endPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, Movespeed * Time.deltaTime);
        }
    }
    public void MoveBackward()
    {
        if (transform.position != startPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, Movespeed * Time.deltaTime);
        }
    }
}
