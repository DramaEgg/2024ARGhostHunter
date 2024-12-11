using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCamera : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float Movespeed = 2f;
    public bool isMoved = false;

    void Start()
    {
        startPosition = GameObject.Find("Main Camera").transform.position;
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0, 0, 3);
        isMoved = true;
    }

    void Update()
    {
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
