using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Canvas pauseCanvas, headerCanvas;

    public void PressedPauseButton(bool enable)
    {
        pauseCanvas.enabled = enable;
    }
}
