using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    /*//public OVRInput.Button shootingBTN;
    public GameObject talisman;
    public LineRenderer linePrefab;
    public Transform shootingPoint;
    public float maxLineDistance = 5;
    public float lineShowTimer = 0.3f;
    float shootingForce = 30f;

    PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory= GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) && playerInventory.CanShoot())
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        Debug.Log("Pew Pew");

        LineRenderer line = Instantiate(linePrefab);
        line.positionCount = 2;
        line.SetPosition(0,shootingPoint.position);

        Vector3 endPoint = shootingPoint.position + shootingPoint.forward* maxLineDistance;

        line.SetPosition(1,endPoint);

        Destroy(line.gameObject, lineShowTimer);

        //222
        GameObject talismanObj = Instantiate(talisman,shootingPoint.position,Quaternion.identity);
        Rigidbody rb = talismanObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 shootDirection = shootingPoint.forward;  // 从发射点的正前方发射
            rb.velocity = shootDirection * shootingForce;

            playerInventory.UseBullet();  // 使用一颗子弹
        }
    }*/
    public GameObject bulletPrefab;  // 子弹预制体
    public Transform shootingPoint;  // 发射位置（玩家的枪口或角色的正前方）
    public float shootingForce = 30f;  // 发射力

    //private PlayerInventory playerInventory;

    void Start()
    {
        //playerInventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))  // 鼠标左键发射子弹
        {
            ShootBullet();
        }
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
