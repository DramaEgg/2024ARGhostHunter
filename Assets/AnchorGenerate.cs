using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AnchorGenerate : MonoBehaviour
{
    public GameObject modelPrefab;
    public Transform RightHandPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnchorIniciate();
    }


    void AnchorIniciate() {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            Instantiate(modelPrefab, RightHandPos.position, Quaternion.identity);
            

        }
    }
}
