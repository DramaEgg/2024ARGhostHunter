using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingZone : MonoBehaviour
{
    public float DecreasedHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        other.gameObject.GetComponent<HealthControl>().CurrentHP--;
    //        other.gameObject.GetComponent<HealthControl>().UpdateHp();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerHealthControl>() != null)
        {
            DecreasedHP = other.gameObject.GetComponent<PlayerHealthControl>().CurrentHP - 5;
            other.gameObject.GetComponent<PlayerHealthControl>().CurrentHP = DecreasedHP;
            other.gameObject.GetComponent<PlayerHealthControl>().UpdateHp();
        }
    }
}
