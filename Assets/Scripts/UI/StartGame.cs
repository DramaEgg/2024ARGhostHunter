using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [Header("References")]
    public Button PlayButton;
    public Button HelpButton;
    public Button ExitButton;
    public SceneLoader CurrentSceneLoader;
    public float PanelMoveSpeed = 10.0f;

    [Header("HelpPanel Related")]
    public GameObject HelpPanel;
    public RectTransform HelpPanelRectTransform;
    public bool IsHelpPanelPopup;
    public bool IsHelpPanelMoving;
    public Vector3 DefaultHelpPanelPos;
    public Vector3 CollapseHelpPanelPos;


    private void Start()
    {
        CurrentSceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();

        if (HelpPanel != null)
        {
            HelpPanelRectTransform = HelpPanel.GetComponent<RectTransform>();
            DefaultHelpPanelPos = HelpPanelRectTransform.position;
            CollapseHelpPanelPos = DefaultHelpPanelPos + new Vector3((HelpPanelRectTransform.rect.width + 50), 0, 0);
            HelpPanelRectTransform.position = CollapseHelpPanelPos;
        }
        if(CurrentSceneLoader != null)
        {
            PlayButton.onClick.AddListener(CurrentSceneLoader.LoadNextScene);
            ExitButton.onClick.AddListener(CurrentSceneLoader.QuitGame);
        }

        HelpButton.onClick.AddListener(SwitchCtrlInfoPanelPopup);
    }


    // Update is called once per frame
    void Update()
    {
        if (HelpPanel != null && HelpPanelRectTransform != null)
            UpdatePanelPopup(ref IsHelpPanelPopup, ref IsHelpPanelMoving, HelpPanelRectTransform, DefaultHelpPanelPos, CollapseHelpPanelPos);
    }

    public void SwitchCtrlInfoPanelPopup()
    {
        IsHelpPanelPopup = !IsHelpPanelPopup;
    } // SwitchCtrlInfoPanelPopup

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
    } // UpdatePanelPopup

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
    } // MovePanel

}
