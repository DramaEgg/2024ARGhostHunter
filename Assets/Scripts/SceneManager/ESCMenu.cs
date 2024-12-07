using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESCMenu : MonoBehaviour
{
    [Header("References")]
    public Button ResumeButton;
    public Button MainMenuButton;
    //public Button HelpButton;
    public Button ExitButton;
    public SceneLoader CurrentSceneLoader;
    public bool isPause = false;
    public GameObject PauseMenu;
    public GameObject[] Info;

    [Header("HelpPanel Related")]
    public GameObject HelpPanel;
    public RectTransform HelpPanelRectTransform;
    public bool IsHelpPanelPopup;
    public bool IsHelpPanelMoving;
    public float PanelMoveSpeed = 10.0f;
    public Vector3 DefaultHelpPanelPos;
    public Vector3 CollapseHelpPanelPos;


    private void Start()
    {
        CurrentSceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();

        //if (HelpPanel != null)
        //{
        //    HelpPanelRectTransform = HelpPanel.GetComponent<RectTransform>();
        //    DefaultHelpPanelPos = HelpPanelRectTransform.position;
        //    CollapseHelpPanelPos = DefaultHelpPanelPos + new Vector3(0, (HelpPanelRectTransform.rect.height + 200), 0);
        //    HelpPanelRectTransform.position = CollapseHelpPanelPos;
        //}
        if (CurrentSceneLoader != null)
        {
            ResumeButton.onClick.AddListener(Resume);
            MainMenuButton.onClick.AddListener(CurrentSceneLoader.LoadStartScene);
            ExitButton.onClick.AddListener(CurrentSceneLoader.QuitGame);
            //HelpButton.onClick.AddListener(SwitchCtrlInfoPanelPopup);
        }

        

    }


    void Update()
    {
            

    }

    public void Resume()
    {
        isPause = false;
        Time.timeScale = 1.0f;
        Info[0].SetActive(true);
        Info[1].SetActive(true);
        PauseMenu.SetActive(false);
    }
    public void SwitchCtrlInfoPanelPopup()
    {
        IsHelpPanelPopup = !IsHelpPanelPopup;
    }


    public void UpdatePanelPopup(ref bool InputPopup, ref bool InputPanelMoving, RectTransform InputPanelRectTrans, Vector3 InputDefaultPos, Vector3 InputCollapsePos)
    {
        if (InputPopup == true)
        {
            if (InputPanelRectTrans.position == InputCollapsePos)
            {
                InputPanelMoving = true;
            }
            MovePanel(InputPanelRectTrans, InputDefaultPos, ref InputPanelMoving);
        }
        else
        {
            if (InputPanelRectTrans.position == InputDefaultPos)
            {
                InputPanelMoving = true;
            }
            MovePanel(InputPanelRectTrans, InputCollapsePos, ref InputPanelMoving);
        }
    }

    public void MovePanel(RectTransform inputPanel, Vector3 InputTargetPos, ref bool InputMoveBool)
    {
        if (InputMoveBool == true && inputPanel.position != InputTargetPos)
        {
            inputPanel.position = Vector3.Lerp(inputPanel.position, InputTargetPos, PanelMoveSpeed * Time.deltaTime);
            if (Vector3.Distance(inputPanel.position, InputTargetPos) <= 0.1)
            {
                inputPanel.position = InputTargetPos;
                InputMoveBool = false;
            }
        }
    } 

}
