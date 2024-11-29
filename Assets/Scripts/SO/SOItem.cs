using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FPS Project/ItemData", fileName = "SOItem", order = 0)]
public class SOItem : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        Key,
        HealthPack
    }

    [Header("General")]
    [SerializeField]
    private string _itemName;
    public string ItemName
    {
        get { return _itemName; }
        set { _itemName = value; }
    }

    [SerializeField]
    private ItemType _type;
    public ItemType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    [SerializeField]
    private Sprite _icon;
    public Sprite Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
}
