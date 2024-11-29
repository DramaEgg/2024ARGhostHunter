using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : Singleton<PlayerInputHandler>
{    
    [Header("Inputs (Needs Hide)")]
    public Vector3 InputMove;
    public Vector2 InputView;

    public bool FireInputWasHeld;
    public bool AimInputWasHeld;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate() 
    {
        FireInputWasHeld = GetFireInputHeld();
        AimInputWasHeld = GetAimInputHeld();
    }

    public bool CanProcessInput()
    {
        return Cursor.lockState == CursorLockMode.Locked;
    }

    public Vector3 GetMoveInput()
    {
        if(CanProcessInput())
        {
            InputMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            InputMove = Vector3.ClampMagnitude(InputMove, 1);

            return InputMove;
        }
        InputMove = Vector3.zero;
        return InputMove;
    }

    public Vector2 GetMouseInput()
    {        
        if(CanProcessInput())
        {
            InputView = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            InputView = Vector2.ClampMagnitude(InputView, 1);

            return InputView;
        }
        InputView = Vector2.zero;
        return InputView;
    }

    public bool GetJumpInputDown()
    {
        if(CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
        return false;
    }

    public bool GetJumpInputHeld()
    {
        if(CanProcessInput())
        {
            return Input.GetKey(KeyCode.Space);
        }
        return false;
    }

    public bool GetCrouchInput()
    {
        if(CanProcessInput())
        {
            return Input.GetKey(KeyCode.C);
        }
        return false;
    }
    public bool GetCrouchInputDown()
    {
        if (CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.C);
        }
        return false;
    }

    public bool GetSprintInput()
    {
        if(CanProcessInput())
        {
            return Input.GetKey(KeyCode.LeftShift);
        }
        return false;
    }

    public bool GetFireInputDown()
    {
        // Debug.Log(GetFireInputHeld() && !FireInputWasHeld);
        FireInputWasHeld = true;
        return GetFireInputHeld() && FireInputWasHeld;
    }

    public bool GetFireInputReleased()
    {
        FireInputWasHeld = false;
        return !GetFireInputHeld() && FireInputWasHeld;
    }

    public bool GetFireInputHeld()
    {
        if(CanProcessInput())
        {
            return Input.GetMouseButton(0);
        }
        return false;
    }

    public bool GetAimInputDown()
    {
        return GetAimInputHeld() && !AimInputWasHeld;
    }

    public bool GetAimInputReleased()
    {
        return !GetAimInputHeld() && AimInputWasHeld;
    }

    public bool GetAimInputHeld()
    {
        if(CanProcessInput())
        {
            return Input.GetMouseButton(1);
        }
        return false;
    }

    public bool GetPickupInput()
    {
        if(CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.E);
        }
        return false;
    }

    public bool GetReloadInput()
    {
        if(CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.R);
        }
        return false;
    }
    public bool GetMiniMapInput()
    {
        if (CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.Q);
        }
        return false;
    }

    public int GetSelectedWeaponInput()
    {
        if (CanProcessInput())
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                return 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                return 2;
            }
        }
        return 0;
    }
    public bool GetBackPackInput()
    {
        if (CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.Tab);
        }
        return false;
    }
    public bool GetHealthPackInput()
    {
        if (CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.X);
        }
        return false;
    }
    public bool GetDoorOpenInput()
    {
        if (CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.F);
        }
        return false;
    }
    public bool GetFirstFireInput()
    {
        if (CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.Alpha1);
        }
        return false;
    }
    public bool GetSecondFireInput()
    {
        if (CanProcessInput())
        {
            return Input.GetKeyDown(KeyCode.Alpha2);
        }
        return false;
    }

}
