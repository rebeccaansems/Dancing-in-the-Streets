using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Canvas pauseCanvas, headerCanvas;

    public static bool isUIOn = false;

    private void Start()
    {
        pauseCanvas.enabled = false;
        headerCanvas.enabled = true;

        isUIOn = pauseCanvas.enabled;
        Time.timeScale = 1;
    }

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

    public void RestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeMusicVolume(float volume)
    {
        Debug.Log(volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        Debug.Log(volume);
    }


    //Dear Code, I do not understand why some letters like float change colour when I type them.; Like Why does public stay blue where bannana stays white - Mergy
}
