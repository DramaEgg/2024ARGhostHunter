using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    public Button toggleButton; // 关联按钮
    public GameObject imageObject; // 关联Image对象

    private bool isImageActive = false; // 初始状态为隐藏

    // Start is called before the first frame update
    void Start()
    {
        if (toggleButton != null && imageObject != null)
        {
            imageObject.SetActive(isImageActive); // 确保初始状态
            toggleButton.onClick.AddListener(ToggleImageVisibility); // 绑定点击事件
        }
    }

    private void ToggleImageVisibility()
    {
        isImageActive = !isImageActive; // 切换状态
        imageObject.SetActive(isImageActive); // 显示或隐藏Image
    }
}
