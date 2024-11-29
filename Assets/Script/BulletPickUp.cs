using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickUp : MonoBehaviour
{
   public PlayerInventory playerInventory;  // 玩家库存
   public GameObject bullet;  // 子弹对象

    public void Start()
    {
        playerInventory=GetComponent<PlayerInventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // 当玩家进入碰撞范围，捡起子弹
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("11Player In");
           
                //playerInventory.PickupBullet();
                Destroy(gameObject);  // 捡起后销毁子弹对象

            
           
        }
    }
    
}
