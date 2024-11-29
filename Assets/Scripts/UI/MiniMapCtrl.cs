using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCtrl : MonoBehaviour
{
    [Header("References")]
    public List<SpriteRenderer> MiniMapIcons;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in MiniMapIcons)
        {
            if (item.gameObject.tag != "Player")
                item.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddIcon(SpriteRenderer inputIcon)
    {
        MiniMapIcons.Add(inputIcon);
    }

    public void RemoveIcon(SpriteRenderer inputIcon)
    {
        MiniMapIcons.Remove(inputIcon);
    }

    public void DisplayIcons(bool inputDisplayBool)
    {
        if (inputDisplayBool == true)
        {
            foreach (var item in MiniMapIcons)
            {
                if (item.gameObject.tag != "Player")
                    item.enabled = true;
            }
        }
        else
        {
            foreach (var item in MiniMapIcons)
            {
                if (item.gameObject.tag != "Player")
                    item.enabled = false;
            }
        }

    }
}
