using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int bulletCount = 0;  // 玩家当前拥有的子弹数

    public void PickupBullet()
    {
        bulletCount++;
        Debug.Log("捡起了子弹，当前拥有子弹数: " + bulletCount);
    }

    public bool CanShoot()
    {
        return bulletCount > 0;
    }

    public void UseBullet()
    {
        if (bulletCount > 0)
        {
            bulletCount--;
            Debug.Log("发射子弹，当前剩余子弹数: " + bulletCount);
        }
    }

}
