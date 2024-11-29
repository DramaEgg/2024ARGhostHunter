using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FPS Project/WeaponData", fileName = "WeaponData", order =1)]
public class SOWeapon : SOItem
{
    public enum WeaponType
    {
        M4Carbine,
        Wingman,
    }
    public enum WeaponStyle 
    {   Primary, 
        Secondary, 
        Melee,
    }
    public enum ShootType 
    {   Repeat, 
        Single, 
    }

    [Header("Weapon-Related")]
    [SerializeField]
    private GameObject _weaponPrefab;
    public GameObject WeaponPrefab
    {
        get { return _weaponPrefab; }
        set { _weaponPrefab = value; }
    }

    [SerializeField] private float _damage;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    [SerializeField] private float _bulletSpeed;
    public float BulletSpeed
    {
        get { return _bulletSpeed; }
        set { _bulletSpeed = value; }
    }

    [SerializeField] private int _ammoNum;
    public int AmmoNum
    {
        get { return _ammoNum; }
        set { _ammoNum = value; }
    }

    [SerializeField] private int _ammoMax;
    public int AmmoMax
    {
        get { return _ammoMax; }
        set { _ammoMax = value; }
    }

    [SerializeField] private float _shotTime;
    public float ShotTime
    {
        get { return _shotTime; }
        set { _shotTime = value; }
    }

    [SerializeField] private float _reloadTime;
    public float ReloadTime
    {
        get { return _reloadTime; }
        set { _reloadTime = value; }
    }

    [SerializeField]
    private float _weaponAimFOV;
    public float WeaponAimFOV
    {
        get { return _weaponAimFOV; }
        set { _weaponAimFOV = value; }
    }

    [SerializeField] private WeaponType _weaponFirearm;
    public WeaponType WeaponFirearm
    {
        get { return _weaponFirearm; }
        set { _weaponFirearm = value; }
    }

    [SerializeField]
    private WeaponStyle m_weaponOrder;
    public WeaponStyle WeaponOrder
    {
        get { return m_weaponOrder; }
        set { m_weaponOrder = value; }
    }

    [SerializeField]
    private ShootType _weaponShootType;
    public ShootType WeaponShootType
    {
        get { return _weaponShootType; }
        set { _weaponShootType = value; }
    }
}
