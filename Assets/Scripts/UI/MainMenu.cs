using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button MainMenuButton;
    public void OnClickLogin()
    {
        SceneManager.LoadScene(0);
    }
    private void Awake()
    {
        MainMenuButton = GetComponent<Button>();
        MainMenuButton.onClick.AddListener(OnClickLogin);
    }
}
