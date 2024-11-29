using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FPS Project/KeyData", fileName = "KeyData", order = 2)]
public class SOKey : SOItem
{
    public enum KeyType
    {
        KeyGreen,
        KeyYellow, 
        KeyRed,
        KeyBlack,
        KeyWhite,
    }

    [SerializeField] private KeyType _currentKey;
    public KeyType CurrentKey
    {
        get { return _currentKey; }
        set { _currentKey = value; }
    }
}
