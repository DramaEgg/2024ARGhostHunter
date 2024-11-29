using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isOwningKey = false;
    public GameObject[] KeyIcon;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKey()
    {
        KeyIcon[0].SetActive(true);
        isOwningKey = true;
    }
}
