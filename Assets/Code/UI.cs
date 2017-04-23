using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Canvas pauseCanvas, headerCanvas;

    public static bool isUIOn = false;

    public void PressedPauseButton()
    {
        pauseCanvas.enabled = !pauseCanvas.enabled;
        isUIOn = pauseCanvas.enabled;

        if (pauseCanvas.enabled)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
