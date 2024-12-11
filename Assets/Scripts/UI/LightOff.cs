using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{
    public GameObject[] Lights;
    public GameObject Block;
    //public AudioSource LightOffAudioSource;
    //public AudioClip LightOffPClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lights[0].activeInHierarchy == false && 
            Lights[1].activeInHierarchy == false &&
            Lights[2].activeInHierarchy == false &&
            Lights[3].activeInHierarchy == false &&
            Lights[4].activeInHierarchy == false &&
            Lights[5].activeInHierarchy == false)
        {
            Block.SetActive(false);
        }
    }
}
