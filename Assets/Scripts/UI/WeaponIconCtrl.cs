using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIconCtrl : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float UnselectedOpacity = 0.5f;
    public Vector3 UnseletedScale = Vector3.one * 0.7f;
    public float ChangeSpeed = 20.0f;
    public WeaponInventory weaponInventory;
    public int WeaponIconIndex;
    public Image Defaulticon;
    public string DefaultName;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        weaponInventory = FindAnyObjectByType<WeaponInventory>();
        DefaultName = Defaulticon.sprite.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Image>().sprite.name == DefaultName)
        {
            //Debug.Log("1: "+GetComponent<Image>().sprite.name);
            //Debug.Log("2: " + DefaultName);
            return;
        }
        bool IsSelected = WeaponIconIndex == weaponInventory.CurrentWeaponIndex;
        if (IsSelected == true)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1.0f, Time.deltaTime * ChangeSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * ChangeSpeed);
        }
        else
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, UnselectedOpacity, Time.deltaTime * ChangeSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale, UnseletedScale, Time.deltaTime * ChangeSpeed);
        }
    }
}
