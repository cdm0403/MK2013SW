using UnityEngine;
using System.Collections;
using System;

public class CameraDeviceMenu : MonoBehaviour
{
    private enum MenuMode
    {
        MENU_OFF,            
        MENU_CAMERA_OPTIONS,
        MENU_FOCUS_MODES     
    }


    private MenuMode mMenuToShow = MenuMode.MENU_OFF;
    private bool mButtonPressed = false;
    private bool mFlashEnabled = false;
    private CameraDevice.FocusMode mFocusMode =
        CameraDevice.FocusMode.FOCUS_MODE_NORMAL;
    private Rect mAreaRect;
    public void Start()
    {
        // Setup position and size of the camera menu.
        computePosition();
    }


    public void OnApplicationPause(bool pause)
    {
        // Upon resuming reactivate the torch if it was active before pausing:
        if (!pause)
        {
            if (mFlashEnabled)
            {
                mFlashEnabled = CameraDevice.Instance.SetFlashTorchMode(true);
            }
        }
    }    

    
    public void Update()
    {
        // If the touch event results from a button press it is ignored.
        if (!mButtonPressed)
        {
            // If finger is removed from screen.
            if (Input.GetMouseButtonUp(0))
            {
                // If menu is not rendered.
                if (mMenuToShow == MenuMode.MENU_OFF)
                {
                    // Show menu.
                    mMenuToShow = MenuMode.MENU_CAMERA_OPTIONS;
                }
                // If menu is already open.
                else
                {
                    // Close menu
                    mMenuToShow = MenuMode.MENU_OFF;
                }
            }
        }
        else
        {
            mButtonPressed = false;
        }
    }

        // Triggers auto focus:
        if (GUILayout.Button("Trigger Autofocus", buttonGroupStyle))
        {
            if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO))
                mFocusMode = CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO;

            mMenuToShow = MenuMode.MENU_OFF;
            mButtonPressed = true;
        }

        if (GUILayout.Button("Focus Modes", buttonGroupStyle))
        {
            mMenuToShow = MenuMode.MENU_FOCUS_MODES;
            mButtonPressed = true;
        }

        GUILayout.EndHorizontal();
        
        GUILayout.EndVertical();

        GUILayout.EndArea();
    }

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        GUILayout.BeginVertical();

        foreach (CameraDevice.FocusMode mode in modes)
        {
            if (mode == setMode)
            {
                GUILayout.Toggle(true, mode.ToString(), activeToggleStyle);
            }
            else
            {
                if (GUILayout.Toggle(false, mode.ToString(), toggleStyle))
                {
                    newMode = mode;
                }
            }
        }

        GUILayout.EndVertical();

        GUILayout.EndArea();

        return newMode;
    }

    private void computePosition()
    {
        int areaWidth = Screen.width;
        int areaHeight = (Screen.height / 5) * 2;
        int areaLeft = 0;
        int areaTop = Screen.height - areaHeight;
        mAreaRect = new Rect(areaLeft, areaTop, areaWidth, areaHeight);
    }

    #endregion // PRIVATE_METHODS
}
