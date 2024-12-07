using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerTriggerClick : MonoBehaviour
{
    public Button uiButton;  // Reference to the UI Button

    void Update()
    {
        // 检查是否按下 Trigger 按钮（例如，Oculus 控制器的 Trigger）
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))  // 如果按下 trigger 按钮
        {
            if (uiButton != null)
            {
                uiButton.onClick.Invoke();  // 触发按钮点击事件
            }
        }
    }
}
