using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaseAnimPlay : MonoBehaviour
{
    public GameObject head;
    //public AnimatorControllerParameter vaseAnimator;
    //public bool isShown;
    private void Start()
    {
        //vaseAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            head.gameObject.SetActive(true);
            GetComponent<Animator>().enabled = true;
            //vaseAnimator.SetBool("isShown", true);
        }

        /*if (other.gameObject.CompareTag("Hand"))
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        head.gameObject.SetActive(false);
        GetComponent<Animator>().enabled = false;
        
        //vaseAnimator.SetBool("isShown", false);
    }

}
    /*
     * 

    */
