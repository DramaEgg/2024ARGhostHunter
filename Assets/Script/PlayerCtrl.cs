using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Player Position")]
        public Transform playerTransform;

    [Header("Bullet")]
        public GameObject bulletPrefab;  // Bullet Prefab
        public Transform shootingPoint;  // Shooting Position
        public float shootingForce = 30f;  // shoot




    //private PlayerInventory playerInventory;

    void Start()
    {
        //playerInventory = GetComponent<PlayerInventory>();
        playerTransform = Camera.main.transform;
    }

    void Update()
    {
        PlayerMovement();

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))  // 鼠标左键发射子弹
        {
            ShootBullet();
        }
    }

    void PlayerMovement() 
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 shootDirection = shootingPoint.forward;  // 从发射点的正前方发射
            rb.velocity = shootDirection * shootingForce;

           // playerInventory.UseBullet();  // 使用一颗子弹
        }
    }
}
