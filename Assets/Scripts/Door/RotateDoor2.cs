using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor2 : MonoBehaviour
{
    public enum OpenState
    {
        Close,
        OpenIn,
        OpenOut,
    }

    public enum DoorType
    {
        SingleSide,
        DoubleSide,
        DoubleDoor,
        EndGameMainDoor,
    }

    [Header("Door Type")]
    public DoorKey.KeyType NeedKeyType;

    [Header("Door Audio")]
    public AudioSource DoorAudioSource;
    public AudioClip openDoorClip;
    public AudioClip openCloseClip;

    [Header("Open/Close Door")]
    public DoorType doorType;
    public OpenState openState;
    public bool IsDoorOpen = false;
    public bool IsDoorOutside = false;
    public float DoorSpeed = 55.0f;
    public float angle = 90.0f;
    public Vector3 DoorOpenPos;
    public Vector3 DoorOpenInPos;
    public Vector3 DoorOpenOutPos;
    public Vector3 DoorClosePos;

    [Header("DoubleDoor")]
    public Transform Door1;
    public Transform Door2;
    public Vector3 Door1OpenPos;
    public Vector3 Door1ClosePos;
    public Vector3 Door2OpenPos;
    public Vector3 Door2ClosePos;

    // Start is called before the first frame update
    void Start()
    {
        //DoorAudioSource = GetComponent<AudioSource>();
        openState = OpenState.Close;
        DoorClosePos = transform.eulerAngles;
        switch (doorType)
        {
            case DoorType.SingleSide:
                DoorOpenPos = new Vector3(DoorClosePos.x,
                                          DoorClosePos.y - angle,
                                          DoorClosePos.z);
                break;
            case DoorType.DoubleSide:
                DoorOpenInPos = new Vector3(DoorClosePos.x,
                                          DoorClosePos.y - angle,
                                          DoorClosePos.z);
                DoorOpenOutPos = new Vector3(DoorClosePos.x,
                                  DoorClosePos.y + angle,
                                  DoorClosePos.z);
                break;
            case DoorType.DoubleDoor:
                Door1ClosePos = Door1.eulerAngles;
                Door2ClosePos = Door2.eulerAngles;
                Door1OpenPos = new Vector3(Door1ClosePos.x,
                                          Door1ClosePos.y - angle,
                                          Door1ClosePos.z);
                Door2OpenPos = new Vector3(Door2ClosePos.x,
                                  Door2ClosePos.y + angle,
                                  Door2ClosePos.z);
                break;
            case DoorType.EndGameMainDoor:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDoorOpen)
        {
            switch (doorType)
            {
                case DoorType.SingleSide:
                    OpenSingleSideDoor();
                    break;
                case DoorType.DoubleSide:
                    OpenDoor();
                    break;
                case DoorType.DoubleDoor:
                    OpenDoubleDoor();
                    break;
            }
        }
        else if (!IsDoorOpen)
        {
            if (doorType == DoorType.DoubleDoor)
            {
                CloseDoubleDoor();
            }
            else
            {
                CloseDoor();
            }
        }
    }
    public void OpenDoubleDoor()
    {
        if (Door1.eulerAngles != Door1OpenPos)
        {
            Door1.rotation = Quaternion.RotateTowards(Door1.rotation, Quaternion.Euler(Door1OpenPos), DoorSpeed * Time.deltaTime);
        }

        if (Door2.eulerAngles != Door2OpenPos)
        {
            Door2.rotation = Quaternion.RotateTowards(Door2.rotation, Quaternion.Euler(Door2OpenPos), DoorSpeed * Time.deltaTime);
        }
    }

    public void CloseDoubleDoor()
    {
        if (Door1.eulerAngles != Door1ClosePos)
        {
            Door1.rotation = Quaternion.RotateTowards(Door1.rotation, Quaternion.Euler(Door1ClosePos), DoorSpeed * Time.deltaTime);
        }

        if (Door2.eulerAngles != Door2ClosePos)
        {
            Door2.rotation = Quaternion.RotateTowards(Door2.rotation, Quaternion.Euler(Door2ClosePos), DoorSpeed * Time.deltaTime);
        }
    }

    public void OpenSingleSideDoor()
    {
        if (transform.eulerAngles != DoorOpenPos)
        {
            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, DoorOpenPos, DoorSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(DoorOpenPos), DoorSpeed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        switch (openState)
        {
            case OpenState.Close:
                break;
            case OpenState.OpenIn:
                if (transform.eulerAngles != DoorOpenInPos)
                {
                    //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, DoorOpenPos, DoorSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(DoorOpenInPos), DoorSpeed * Time.deltaTime);
                    //Debug.Log("Opening");
                }
                break;
            case OpenState.OpenOut:
                if (transform.eulerAngles != DoorOpenOutPos)
                {
                    //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, DoorOpenPos, DoorSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(DoorOpenOutPos), DoorSpeed * Time.deltaTime);
                    //Debug.Log("Opening");
                }
                break;
        }
    }

    public void CloseDoor()
    {
        if (transform.eulerAngles != DoorClosePos)
        {
            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, DoorClosePos, DoorSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(DoorClosePos), DoorSpeed * Time.deltaTime);
        }
    }

    public void PlayDoorAudio()
    {
        if (IsDoorOpen)
        {
            //DoorAudioSource.clip = openDoorClip;
            DoorAudioSource.PlayOneShot(openDoorClip);
        }
        else
        {
            //DoorAudioSource.clip = openCloseClip;
            DoorAudioSource.PlayOneShot(openCloseClip);
        }
    }
}
