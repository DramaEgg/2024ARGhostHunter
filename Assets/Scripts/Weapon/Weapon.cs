using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
//using UnityEngine.Rendering.VirtualTexturing;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public GameObject BullectPrefab;
    public ParticleSystem FireParticleSystem;
    public Transform _spawnRoot;
    //public Transform _cameraTransform;
    public Animator _animator;

    [Header("Fire")]
    public SOWeapon currentWeapon;
    public int CurrentAmmo;
    public float CurrentShotTime;
    private Coroutine _ReloadingRoutine;
    public bool IsLoading;

    [Header("Calculations")]
    public Vector2 ScreenCenterPosition;
    public Vector3 bulletRotation;
    public Vector3 hitPosition;
    public Ray WeaponRay;
    public RaycastHit hitInfo;

    void Start()
    {
        //_cameraTransform = GameObject.Find("CameraRoot").transform;
        //_spawnRoot = GameObject.Find("SpawnRoot").transform;
        ScreenCenterPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        _animator = GetComponent<Animator>();
        CurrentAmmo = currentWeapon.AmmoMax;
    }

    void Update()
    {
        WeaponRay = Camera.main.ScreenPointToRay(ScreenCenterPosition);
        //Debug.DrawRay(WeaponRay.origin, WeaponRay.direction * 20.0f, Color.green);
        bulletRotation = Vector3.zero;

        if (Input.GetMouseButtonDown(0) && CurrentAmmo > 0 && CurrentShotTime <= 0 && IsLoading == false)
        {
            if (Physics.Raycast(WeaponRay, out hitInfo, 100.0f))
            {
                FireParticleSystem.Play();
                hitPosition = hitInfo.point;
                bulletRotation = (hitPosition - _spawnRoot.position).normalized;
                Instantiate(BullectPrefab, _spawnRoot.position, Quaternion.LookRotation(bulletRotation, Vector3.up));
                Debug.Log("--- Generated Bullet");
                _animator.SetTrigger("Fire");
                CurrentAmmo --;
                CurrentShotTime = currentWeapon.ShotTime;
            }
        }

        if(CurrentAmmo <= 0 && IsLoading == false)
        {
            if (_ReloadingRoutine != null) StopCoroutine(ReloadWeapon());
            _ReloadingRoutine = StartCoroutine(ReloadWeapon());
        }

        if (Input.GetKeyDown(KeyCode.R) && IsLoading == false)
        {
            if (_ReloadingRoutine != null) StopCoroutine(ReloadWeapon());
            _ReloadingRoutine = StartCoroutine(ReloadWeapon());
        }

        if(CurrentShotTime > 0)
            CurrentShotTime -= Time.deltaTime;
    }

    public IEnumerator ReloadWeapon()
    {
        Debug.Log("Start Reload Func --- ");
        IsLoading = true;
        yield return new WaitForSeconds(currentWeapon.ReloadTime);
        CurrentAmmo = currentWeapon.AmmoMax;
        IsLoading = false;
    }
}
