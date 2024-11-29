using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("References")]
    public PlayerControl _playerControl;
    public Transform DefaultWeaponPosition;
    public Transform SprintWeaponPosition;
    public Transform AimWeaponPosition;
    public Transform SwitchWeaponPosition;

    [Header("View Sway")]
    public bool ViewSwayXInverted;
    public bool ViewSwayYInverted;
    public float ViewSwayValue = 8.0f;
    public float ViewSwaySmoothing = 0.05f;
    public float ViewSwayClampX = 20.0f;
    public float ViewSwayClampY = 20.0f;

    [Header("Move Sway")]
    public bool MoveSwayXInverted;
    public bool MoveSwayYInverted;
    public float MoveSwayValue = 8.0f;
    public float MoveSwaySmoothing = 0.05f;

    [Header("Weapon Sprint")]
    public float speed = 5.0f;
    public float CountDown = 0.1f;
    public bool ReturnSway;

    [Header("View Sway Calculations")]
    public Vector3 currentViewRotation;
    public Vector3 currentViewRotationVelocity;
    public Vector3 TargetViewRotation;

    [Header("Move Sway Calculations")]
    public Vector3 currentMoveRotation;
    public Vector3 currentMoveRotationVelocity;
    public Vector3 TargetMovewRotation;

    [Header("Aim")]
    public float AimSpeed = 5.0f;
    public float DefaultFOV = 70.0f;
    public float AimFOV = 60.0f;

    [Header("Weapon Switch")]
    public float SwitchSpeed;
    public bool IsSelected = false;


    void Start()
    {
        _playerControl = FindAnyObjectByType<PlayerControl>();
        DefaultWeaponPosition = GameObject.Find("DefaultPos").transform;
        SprintWeaponPosition = GameObject.Find("SprintPos").transform;
        AimWeaponPosition = GameObject.Find("AimPos").transform;
        SwitchWeaponPosition = GameObject.Find("SwitchPos").transform;
    }

    void Update()
    {
        if (IsSelected)
        {
            UpdateWeaponSprint();
            UpdateWeaponSway();
            UpdateWeaponAim();
        }
        else
        {
            UpdateWeaponSwitch();
        }
    }

    public void UpdateWeaponAim()
    {
        if (PlayerInputHandler.Instance.AimInputWasHeld == true)
        {
            //Debug.Log("StartAim");
            if (transform.position != AimWeaponPosition.position)
            {
                //Debug.Log("44");
                transform.position = Vector3.Lerp(transform.position, AimWeaponPosition.position, AimSpeed * Time.deltaTime);
            }
            //transform.position = Vector3.Lerp(transform.position, AimWeaponPosition.position, AimSpeed * Time.deltaTime);
            //SetCameraFOV(Camera.main, AimFOV);
        }
        else
        {
            //Debug.Log("StartDefault");
            if (transform.position != DefaultWeaponPosition.position)
            {
                //Debug.Log("22");
                transform.position = Vector3.Lerp(transform.position, DefaultWeaponPosition.position, AimSpeed * Time.deltaTime);
            }
            //transform.position = Vector3.Lerp(transform.position, DefaultWeaponPosition.position, AimSpeed * Time.deltaTime);
            //SetCameraFOV(Camera.main, DefaultFOV);
        }
    }

    public void SetCameraFOV(Camera inputCamera, float inputFOV)
    {
        inputCamera.fieldOfView = Mathf.Lerp(inputCamera.fieldOfView,inputFOV, Time.deltaTime * AimSpeed);
    }

    public void UpdateWeaponSprint()
    {
        if(_playerControl.InputSprint == true)
        {
            if (transform.position != SprintWeaponPosition.position)
            {
                transform.position = Vector3.Lerp(transform.position, SprintWeaponPosition.position, speed * Time.deltaTime);
            }
            if ((int)transform.rotation.eulerAngles.y != (int)SprintWeaponPosition.rotation.eulerAngles.y)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, SprintWeaponPosition.rotation, speed * Time.deltaTime);
            }
            ReturnSway = false;
            CountDown = 2.0f;
        }
        //按下Shift后,冲刺为真，此时如果武器位置不在冲刺武器位置，那么武器位移+旋转到武器冲刺位置。
        //同时不触发偏摆回归，倒计时设置为0.1秒
        else if (_playerControl.InputSprint == false && ReturnSway == false)
        {
            CountDown -= Time.deltaTime;
            if (transform.position != DefaultWeaponPosition.position)
            {
                transform.position = Vector3.Lerp(transform.position, DefaultWeaponPosition.position, speed * Time.deltaTime);
            }
            if ((int)transform.rotation.eulerAngles.y != (int)DefaultWeaponPosition.rotation.eulerAngles.y)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, DefaultWeaponPosition.rotation, speed * Time.deltaTime);
            }

            if(CountDown <= 0)
            {
                ReturnSway = true;
            }
            //松开Shift后,冲刺为假，开始倒计时。此时如果武器位置不在原始位置，且不触发偏摆回归，那么武器位移+旋转到武器原始位置。
            //当倒计时小于等于零时，触发偏摆回归。

        }
    }

    public void UpdateWeaponSway()
    {
        if (ReturnSway)
        {
            // View
            TargetViewRotation.x = (ViewSwayXInverted ? _playerControl.InputView.y : -_playerControl.InputView.y) * ViewSwayValue;
            TargetViewRotation.y = (ViewSwayYInverted ? _playerControl.InputView.x : -_playerControl.InputView.x) * ViewSwayValue;

            TargetViewRotation.x = Mathf.Clamp(TargetViewRotation.x, -ViewSwayClampX, ViewSwayClampX);
            TargetViewRotation.y = Mathf.Clamp(TargetViewRotation.y, -ViewSwayClampY, ViewSwayClampY);

            currentViewRotation = Vector3.SmoothDamp(currentViewRotation, TargetViewRotation, ref currentViewRotationVelocity, ViewSwaySmoothing);

            //InputView = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            //目标沿x轴旋转（上下）的视野旋转值为InputView的x（Mouse Y）乘以偏摆值
            //目标沿y轴旋转（左右）的视野旋转值为InputView的y（Mouse X）乘以偏摆值
            //设置是否Inverted决定x和y的正负值
            //为了避免武器一直旋转的情况发生，用Mathf.Clamp设置偏摆的范围
            //最终由鼠标输入决定的视野偏摆旋转值用SmoothDamp的方法，输入当前视野旋转值和上面计算得到的目标视野旋转值得出

            // Move
            TargetMovewRotation.z = (MoveSwayXInverted ? _playerControl.InputMove.x : -_playerControl.InputMove.x) * MoveSwayValue;
            TargetMovewRotation.x = (MoveSwayYInverted ? _playerControl.InputMove.z : -_playerControl.InputMove.z) * MoveSwayValue;
            currentMoveRotation = Vector3.SmoothDamp(currentMoveRotation, TargetMovewRotation, ref currentMoveRotationVelocity, MoveSwaySmoothing);

            transform.localRotation = Quaternion.Euler(currentViewRotation + currentMoveRotation);
            //InputMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
            //目标沿z轴旋转（左右）的移动旋转值为InputMove的x（左右）乘以偏摆值
            //目标沿x轴旋转（上下）的移动旋转值为InputMove的z（上下）乘以偏摆值
            //设置是否Inverted决定x和y的正负值
            //最终由键盘输入决定的移动偏摆旋转值用SmoothDamp的方法，输入当前移动旋转值和上面计算得到的目标移动旋转值得出
            //最终武器偏摆值=欧拉角（目标视野偏摆旋转值+目标移动偏摆旋转值）
        }
    }

    public void UpdateWeaponSwitch()
    {
        if (!IsSelected)
        {
            if (transform.position != SwitchWeaponPosition.position)
            {
                transform.position = Vector3.Lerp(transform.position, SwitchWeaponPosition.position, SwitchSpeed * Time.deltaTime);
            }
            if (transform.position.y < 1f && this.gameObject.active == true)
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            if (transform.position != DefaultWeaponPosition.position)
            {
                transform.position = Vector3.Lerp(transform.position, DefaultWeaponPosition.position, SwitchSpeed * Time.deltaTime);
            }
        }
    }
}



