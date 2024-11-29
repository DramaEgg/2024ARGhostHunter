using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(Camera.main.transform.forward);
        this.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
