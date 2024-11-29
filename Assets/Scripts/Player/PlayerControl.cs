using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.EventSystems.StandaloneInputModule;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    [Header("References")]
    public CharacterController _characterController;
    public Transform _characterTransform;
    public Transform _cameraTransform;

    [Header("Player Input")]
    public Vector3 InputMove;
    public Vector3 InputView;
    public bool InputSprint;

    [Header("Movement")]
    [Tooltip("Player normal speed.")] public float walkSpeed = 5f;
    [Min(6)] public float sprintingSpeed = 10f;
    public float CrounchSpeed = 2f;
    private Vector3 _movementDirection;
    public float _currentSpeed;

    [Header("Rotation")]
    [Range(1, 15)]
    public float MouseXSensitivity = 5.0f;
    [Range(1, 15)]
    public float MouseYSensitivity = 5.0f;
    public float MouseYClampMin = -60.0f;
    public float MouseYClampMax = 60.0f;
    private Vector3 newPlayerRotation;
    private Vector3 newCameraRotation;

    [Header("Jump & Crouch")]
    public float gravity = 6.0f;
    public float jumpHeight = 2f;
    public float crouchHeight = 1f;
    public bool isCrouched;
    private float originHeight;
    private float _currentHeight;

    [Header("MiniMap Control")]
    public MiniMapCtrl miniMapCtrl;
    public bool IsMiniMapTargetDisplay = false;
    public float MinimapCountdownTime = 3.0f;
    private Coroutine StartMinimapCountDown;

    void Start()
    {
        _cameraTransform = GameObject.Find("CameraRoot").transform;
        _characterController = GetComponent<CharacterController>();
        _characterTransform = transform;
        originHeight = _characterController.height;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        UpdateCameraRotate();
        UpdateMiniMap();
        UpdateMoveAndJump();
        UpdateCrouch();
        UpdateSprint();

        _characterController.Move(_currentSpeed * Time.deltaTime * _movementDirection);
    }
    private void UpdateCameraRotate()
    {
        InputView = PlayerInputHandler.Instance.GetMouseInput();
        newCameraRotation.x -= InputView.y * MouseYSensitivity;
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x, MouseYClampMin, MouseYClampMax);
        _cameraTransform.localRotation = Quaternion.Euler(newCameraRotation);

        newPlayerRotation.y += InputView.x * MouseXSensitivity;
        _characterTransform.localRotation = Quaternion.Euler(newPlayerRotation);
    }
    private void UpdateMiniMap()
    {
        if (PlayerInputHandler.Instance.GetMiniMapInput() && IsMiniMapTargetDisplay == false)
        {
            IsMiniMapTargetDisplay = !IsMiniMapTargetDisplay;
            miniMapCtrl.DisplayIcons(IsMiniMapTargetDisplay);
            if (IsMiniMapTargetDisplay == true)
            {
                if (StartMinimapCountDown != null) StopCoroutine(StartMinimapCountDown);
                StartMinimapCountDown = StartCoroutine(MiniMapHideCountDown());
            }
        }

    }
    private IEnumerator MiniMapHideCountDown()
    {
        yield return new WaitForSeconds(MinimapCountdownTime);
        IsMiniMapTargetDisplay = !IsMiniMapTargetDisplay;
        miniMapCtrl.DisplayIcons(IsMiniMapTargetDisplay);
    }
    private void UpdateMoveAndJump()
    {
        _currentSpeed = walkSpeed;
        if (_characterController.isGrounded)
        {
            InputMove = PlayerInputHandler.Instance.GetMoveInput();
            _movementDirection = _characterTransform.TransformDirection(InputMove);

            if (PlayerInputHandler.Instance.GetJumpInputDown())
            {
                _movementDirection.y = jumpHeight;
            }
        }
        _movementDirection.y -= gravity * Time.deltaTime;

    }
    private void UpdateCrouch()
    {
        if (PlayerInputHandler.Instance.GetCrouchInputDown())
        {
            _currentHeight = isCrouched ? originHeight : crouchHeight;
            StartCoroutine(DoCrouch(_currentHeight));
            isCrouched = !isCrouched;
        }
        if (isCrouched == true && _currentHeight == crouchHeight)
        {
            _currentSpeed = CrounchSpeed;
        }
    }
    private IEnumerator DoCrouch(float target)
    {
        float temp_currentHeight = 0;
        while (Mathf.Abs(_characterController.height - target) > 0.1f)
        {
            yield return null;
            _characterController.height = Mathf.SmoothDamp(_characterController.height, target, ref temp_currentHeight, Time.deltaTime * 5);
        }
    }
    private void UpdateSprint()
    {
        if (isCrouched == false && _currentHeight != crouchHeight)
        {
            InputSprint = PlayerInputHandler.Instance.GetSprintInput();
            _currentSpeed = InputSprint ? sprintingSpeed : walkSpeed;
        }

    }
}

