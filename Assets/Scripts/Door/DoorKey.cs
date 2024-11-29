using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public enum KeyType
    {
        None,
        Green,
        Red,
        Blue,
        Yellow,
        White,
    }

    [SerializeField] private KeyType doorKeyType;
    public KeyType DoorKeyType
    {
        get { return doorKeyType; }
        set { doorKeyType = value; }
    }

    public Color KeyColor;
}
