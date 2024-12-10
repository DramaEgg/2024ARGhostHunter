using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCtrl : MonoBehaviour
{
    public GameObject EnemyDeadBody;
    public GameObject DeadBodyUI;
    public bool isPickable = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyDeadBody.GetComponent<Enemy>().isDead )
        {
            isPickable = true;
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("DeadEnemy"))
    //    {
    //        if (isPickable)
    //        {
    //            DeadBodyUI.SetActive(true);
    //            Destroy(this.gameObject, 5);
    //        }
    //    }

    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("DeadEnemy"))
    //    {
    //        if (isPickable)
    //        {
    //            DeadBodyUI.SetActive(true);
    //            Destroy(EnemyDeadBody.gameObject, 5);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadEnemy"))
        {
            if (isPickable)
            {
                Debug.Log("OK!");
                DeadBodyUI.SetActive(true);
                EnemyDeadBody.SetActive(false);
            }
        }
    }
}
