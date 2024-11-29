using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SOKey;

[CreateAssetMenu(menuName = "FPS Project/HealthPackData", fileName = "HealthPackData", order = 3)]
public class SOHealthPack : SOItem
{
    [SerializeField] private int _itemCount;
    public int ItemCount
    {
        get { return _itemCount; }
        set { _itemCount = value; }
    }

    [SerializeField] private float _healNum;
    public float HealNum
    {
        get { return _healNum; }
        set { _healNum = value; }
    }
}
