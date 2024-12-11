using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public GameObject weaponInfo;
    public GameObject BuleLight;
    public AudioSource weaponAudio;
    public AudioClip weaponInfoClip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            weaponAudio.PlayOneShot(weaponInfoClip);
            weaponInfo.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Player")
        {
            weaponInfo.SetActive(false);
            BuleLight.SetActive(false);
        }
    }
}
