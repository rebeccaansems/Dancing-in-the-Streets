using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [Tooltip("Pause: 0, Header: 1, HighScore: 2, GameOver: 3")]
    public Canvas pauseCanvas, headerCanvas, highScoresCanvas, gameOverCanvas;
    public Button pauseButton;

    public static bool isUIOn = false;

    private void Start()
    {
        pauseCanvas.enabled = false;
        highScoresCanvas.enabled = false;
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

    public void PressedRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PressedHighScoresButton()
    {
        highScoresCanvas.enabled = !highScoresCanvas.enabled;
        pauseCanvas.enabled = false;
    }

    public void PressedBackButton(string canvasSwap)
    {
        int position = canvasSwap.IndexOf(" ");
        int previousCanvas = int.Parse(canvasSwap.Substring(0, position));
        int currentCanvas = int.Parse(canvasSwap.Substring(position + 1));

        switch (previousCanvas)
        {
            case 0:
                pauseCanvas.enabled = true;
                break;
            case 1:
                headerCanvas.enabled = true;
                break;
            case 2:
                highScoresCanvas.enabled = true;
                break;
            case 3:
                gameOverCanvas.enabled = true;
                break;
        }

        switch (currentCanvas)
        {
            case 0:
                pauseCanvas.enabled = false;
                break;
            case 1:
                headerCanvas.enabled = false;
                break;
            case 2:
                highScoresCanvas.enabled = false;
                break;
            case 3:
                gameOverCanvas.enabled = false;
                break;
        }
    }

    public void PlayerDied()
    {
        gameOverCanvas.enabled = true;
        pauseCanvas.enabled = false;
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
