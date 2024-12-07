using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ssTest : MonoBehaviour
{
    [Header("References")]
    public Button PlayButton;
    //public Button TryButton;
    public Button HelpButton;
    public Button ExitButton;
    public SceneLoader CurrentSceneLoader;
    public float PanelMoveSpeed = 10.0f;

    [Header("HelpPanel Related")]
    public GameObject HelpPanel;
    public RectTransform HelpPanelRectTransform;
    //public RectTransform DeadPanelRectTransform;
    //public bool IsDeadPanelPopup;
    public bool IsHelpPanelPopup;
    public bool IsHelpPanelMoving;
    //public bool IsDeadPanelMoving;
    public Vector3 DefaultHelpPanelPos;
    //public Vector3 DefaultDeadPanelPos;
    public Vector3 CollapseHelpPanelPos;
    //public Vector3 DeadpseHelpPanelPos;


    private void Start()
    {
        CurrentSceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();

        if (HelpPanel != null)
        {
            HelpPanelRectTransform = HelpPanel.GetComponent<RectTransform>();
            //DeadPanelRectTransform = HelpPanel.GetComponent<RectTransform>();
            DefaultHelpPanelPos = HelpPanelRectTransform.position;
            //DefaultDeadPanelPos = DeadPanelRectTransform.position;
            CollapseHelpPanelPos = DefaultHelpPanelPos + new Vector3(0, (HelpPanelRectTransform.rect.height + 200), 0);
            //DeadpseHelpPanelPos = DefaultDeadPanelPos + new Vector3(0, (DeadPanelRectTransform.rect.height + 50), 0);
            HelpPanelRectTransform.position = CollapseHelpPanelPos;
            //DeadPanelRectTransform.position = DeadpseHelpPanelPos;
        }
        if (CurrentSceneLoader != null)
        {
            PlayButton.onClick.AddListener(CurrentSceneLoader.LoadNextScene);
            //TryButton.onClick.AddListener(CurrentSceneLoader.LoadGameScene);
            ExitButton.onClick.AddListener(CurrentSceneLoader.QuitGame);
        }

        HelpButton.onClick.AddListener(SwitchCtrlInfoPanelPopup);
        //HelpButton.onClick.AddListener(SwitchDeadlInfoPanelPopup);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (HelpPanel != null && HelpPanelRectTransform != null)
            UpdatePanelPopup(ref IsHelpPanelPopup, ref IsHelpPanelMoving, HelpPanelRectTransform, DefaultHelpPanelPos, CollapseHelpPanelPos);
        //if (HelpPanel != null && DeadPanelRectTransform != null)
        //    UpdateDeadPopup(ref IsDeadPanelPopup, ref IsDeadPanelMoving, DeadPanelRectTransform, DefaultDeadPanelPos, DeadpseHelpPanelPos);
    }

    public void SwitchCtrlInfoPanelPopup()
    {
        IsHelpPanelPopup = !IsHelpPanelPopup;
    }
    //public void SwitchDeadlInfoPanelPopup()
    //{
    //    IsDeadPanelPopup = !IsDeadPanelPopup;
    //} // SwitchCtrlInfoPanelPopup

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
    //public void UpdateDeadPopup(ref bool InputPopup, ref bool InputPanelMoving, RectTransform InputPanelRectTrans, Vector3 InputDefaultPos, Vector3 InputCollapsePos)
    //{
    //    if (InputPopup == true)
    //    {
    //        if (InputPanelRectTrans.position == InputCollapsePos)
    //        {
    //            InputPanelMoving = true;
    //        }
    //        MovePanel(InputPanelRectTrans, InputDefaultPos, ref InputPanelMoving);
    //    }
    //    else
    //    {
    //        if (InputPanelRectTrans.position == InputDefaultPos)
    //        {
    //            InputPanelMoving = true;
    //        }
    //        MovePanel(InputPanelRectTrans, InputCollapsePos, ref InputPanelMoving);
    //    }
    //} // UpdatePanelPopup

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
    // MovePanel
}
