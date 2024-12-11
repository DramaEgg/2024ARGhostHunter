using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class AlignToGround : MonoBehaviour
{

    public float groundY = 0f;  // 虚拟地面的 y 位置

    void Start()
    {
        // 获取当前相机的实际高度
        var cameraHeight = Camera.main.transform.position.y;

        // 调整 XR Origin 的高度
        var origin = GetComponent<XROrigin>();
        if (origin != null)
        {
            origin.transform.position = new Vector3(
                origin.transform.position.x,
                groundY - cameraHeight,
                origin.transform.position.z
            );
        }


    }
}
