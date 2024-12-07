using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("References")]
    public GameObject TalismanPrefab;
    public ParticleSystem FireParticleSystem;
    public Transform _spawnRoot;
    public Camera RayCamera;
    //public Animator _animator;

    [Header("Fire")]
    public int CurrentTalisman;
    public int ReloadTime = 1;
    private Coroutine _ReloadingRoutine;
    public bool IsLoading;

    [Header("Calculations")]
    public Vector2 ScreenCenterPosition;
    public Vector3 TalismanRotation;
    public Vector3 hitPosition;
    public Ray TalismanRay;
    public RaycastHit hitInfo;

    [Header("Test")]
    public float widthNum = 0.8f;
    public float heightNum = 0.4f;

    void Start()
    {
        ScreenCenterPosition = new Vector2(Screen.width / widthNum, Screen.height / heightNum);
        //ScreenCenterPosition = new Vector2( widthNum, heightNum );
        CurrentTalisman = 0;
        //_animator = GetComponent<Animator>();
    }

    void Update()
    {
        TalismanRay = RayCamera.ScreenPointToRay(ScreenCenterPosition);
        Debug.DrawRay(TalismanRay.origin, TalismanRay.direction * 100.0f, Color.green);
        TalismanRotation = Vector3.zero;

        if ((OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) && CurrentTalisman > 0 && !IsLoading)
        {
            Debug.Log("Button down");
            if (Physics.Raycast(TalismanRay, out hitInfo, 100.0f))
            {
                hitPosition = hitInfo.point;
                TalismanRotation = (hitPosition - _spawnRoot.position).normalized;
                Instantiate(TalismanPrefab, _spawnRoot.position, Quaternion.LookRotation(TalismanRotation, Vector3.up));
                //FireParticleSystem.Play();
                CurrentTalisman--;
                _ReloadingRoutine = StartCoroutine(ReloadTalisman());
            }
        }
    }

    public IEnumerator ReloadTalisman()
    {
        Debug.Log("Start Reload Func --- ");
        IsLoading = true;
        yield return new WaitForSeconds(ReloadTime);
        IsLoading = false;
    }
}
