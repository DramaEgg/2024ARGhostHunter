using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OVRButtonInteraction : MonoBehaviour
{
    public Transform rightHandAnchor; // 手柄锚点
    public LineRenderer lineRenderer; // 射线可视化
    public float maxRayDistance = 300f; // 射线最大距离


    private void Start()
    {
        if (lineRenderer != null && lineRenderer.positionCount != 2)
        {
            lineRenderer.positionCount = 2; // 设置起点和终点
        }

    }
    private void Update()
    {



        // 使用右手手柄发射射线
        Vector3 rayOrigin = rightHandAnchor.position;
        Vector3 rayDirection = rightHandAnchor.forward;

        // 射线检测
        Ray ray = new Ray(rayOrigin, rayDirection);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit, maxRayDistance);

        // 更新射线可视化
        if (lineRenderer)
        {
            lineRenderer.SetPosition(0, rayOrigin);
            lineRenderer.SetPosition(1, isHit ? hit.point : rayOrigin + rayDirection * maxRayDistance);
        }

        // 检测到 UI 对象
        if (isHit && hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;

            // 判断是否是按钮并处理点击事件
            Button button = hitObject.GetComponent<Button>();
            if (button != null && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                button.onClick.Invoke(); // 手动触发按钮点击事件
            }
        }
    }
}
