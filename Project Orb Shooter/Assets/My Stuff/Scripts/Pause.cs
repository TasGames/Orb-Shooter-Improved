using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] protected GameObject pauseMenu;

    protected bool disableInput;
    InputDevice inputDevice;

    void Start()
    {
        inputDevice = InputManager.ActiveDevice;
    }

    void Update()
    {
        UpdateInputDevice(inputDevice);
        pauseIt();
    }

    void UpdateInputDevice(InputDevice inputDevice_)
    {
        if (disableInput)
            return;

        if (inputDevice_.Action4.WasPressed)
            isPaused = true;

    }

    void pauseIt()
    {
        if (isPaused == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}