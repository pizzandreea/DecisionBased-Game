using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    float previousTimeScale = 1;
    public static bool isPaused;
    public GameObject pauseMenuUi;

    private void Awake()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if (isPaused)
        {
            pauseMenuUi.SetActive(true);
        }
        else
        {
            pauseMenuUi.SetActive(false);
        }
    }

    public void TogglePause()
    {
        if(Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;

            isPaused = true;
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = previousTimeScale;
            AudioListener.pause = false;
            isPaused = false;
        }
    }

    public bool checkIfPaused()
    {
        return isPaused;
    }
}
