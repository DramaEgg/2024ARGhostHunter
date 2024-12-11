using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    public Animator LoadSceneAnimator;
    public float LoadSceneTime = 2.0f;

    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

    }

    public void LoadNextScene()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadBackScene()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex -2));
    }

    public void LoadStartScene()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        StartCoroutine(LoadScene(0));
    }    
    public void LoadGameScene()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        StartCoroutine(LoadScene(2));
    }
    public void LoadEndScene()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        StartCoroutine(LoadScene(4));
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator LoadScene(int SceneIndex)
    {
        LoadSceneAnimator.SetBool("FadeIn", true);
        yield return new WaitForSeconds(LoadSceneTime);

        AsyncOperation async = SceneManager.LoadSceneAsync(SceneIndex);
        async.completed += OnLoadedScene;
    }

    private void OnLoadedScene(AsyncOperation operation)
    {
        LoadSceneAnimator.SetBool("FadeIn", false);
    }

}
