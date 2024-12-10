using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu; // 关联PauseMenu对象
    public KeyCode toggleKey = KeyCode.Escape; // 默认按键为Esc

    private bool isPaused = false; // 初始状态未暂停

   
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            TogglePauseMenu(); // 检测按键并切换PauseMenu
        }
    }

    private void TogglePauseMenu()
    {
        isPaused = !isPaused; // 切换状态
        pauseMenu.SetActive(isPaused); // 显示或隐藏PauseMenu

        // 如果需要暂停游戏
        Time.timeScale = isPaused ? 0 : 1; // 游戏暂停或恢复
    }

}
