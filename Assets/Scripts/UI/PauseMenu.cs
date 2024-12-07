using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //public GameObject pauseCanvas;  // Canvas对象
    public GameObject ResumeButton;
    public GameObject MainMenuButton;
    public GameObject QuitButton;
    bool isPause = false;

    void Start()
    {
        //pauseCanvas.SetActive(false);
        QuitButton.SetActive(false);
        ResumeButton.SetActive(false);
        MainMenuButton.SetActive(false);

        ResumeButton.GetComponent<Button>().onClick.AddListener(ResumeEvent);
        QuitButton.GetComponent<Button>().onClick.AddListener(QuitEvent);
        MainMenuButton.GetComponent<Button>().onClick.AddListener(MainMenuEvent);
    }
    public void ResumeEvent()
    {
        isPause = false;
        QuitButton.SetActive(false);
        ResumeButton.SetActive(false);
        MainMenuButton.SetActive(false);
        //pauseCanvas.SetActive(false);  // 关闭Pause菜单Canvas
        Time.timeScale = 1.0f;

      

    }
    public void QuitEvent()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    public void MainMenuEvent()
    {
        // 恢复时间流逝
        Time.timeScale = 1.0f;

        // 加载主菜单场景
        SceneManager.LoadScene("StartGameMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)

        {

            isPause = true;
            //pauseCanvas.SetActive(true);  // 显示Pause菜单Canvas
            QuitButton.SetActive(true);
            ResumeButton.SetActive(true);
            MainMenuButton.SetActive(true);
            Time.timeScale = 0.0f;
 
            ResetButtonAnimator(ResumeButton);
            ResetButtonAnimator(MainMenuButton);
            ResetButtonAnimator(QuitButton);

        }

        else if (Input.GetKeyDown(KeyCode.Escape)&& isPause)
        { 
            ResumeEvent(); 
        } 
    }

    private void ResetButtonAnimator(GameObject button)
    {
        Animator animator = button.GetComponent<Animator>();
        if (animator != null)
        {
            // 重置所有动画参数，确保状态一致
            foreach (AnimatorControllerParameter parameter in animator.parameters)
            {
                if (parameter.type == AnimatorControllerParameterType.Bool)
                {
                    animator.SetBool(parameter.name, false);
                }
                else if (parameter.type == AnimatorControllerParameterType.Float)
                {
                    animator.SetFloat(parameter.name, 0f);
                }
                else if (parameter.type == AnimatorControllerParameterType.Int)
                {
                    animator.SetInteger(parameter.name, 0);
                }
                else if (parameter.type == AnimatorControllerParameterType.Trigger)
                {
                    animator.ResetTrigger(parameter.name);
                }
            }

            // 强制重置动画状态
            animator.Rebind();
            animator.Update(0f);

            // 确保动画使用Unscaled Time播放并刷新
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;

            // 手动触发动画播放
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0f);
        }
    }

}
   
  