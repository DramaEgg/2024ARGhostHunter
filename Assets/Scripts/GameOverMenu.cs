using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [Header("References")]
    public Button TryButton;
    public Button ExitButton;
    public SceneLoader CurrentSceneLoader;

    private void Start()
    {
        CurrentSceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();

        if (CurrentSceneLoader != null)
        {
            TryButton.onClick.AddListener(CurrentSceneLoader.LoadStartScene);
            ExitButton.onClick.AddListener(CurrentSceneLoader.QuitGame);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
