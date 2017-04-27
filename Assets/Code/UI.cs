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
    public GameObject player;

    public static bool isUIOn = false;

    private Canvas currentCanvas, previousCanvas;

    private void Start()
    {
        pauseCanvas.enabled = false;
        highScoresCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        headerCanvas.enabled = true;

        isUIOn = pauseCanvas.enabled;
        Time.timeScale = 1;
    }

    public void PressedPauseButton()
    {
        pauseCanvas.enabled = !pauseCanvas.enabled;
        isUIOn = pauseCanvas.enabled;

        currentCanvas = pauseCanvas;
        previousCanvas = null;

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
        AnalyticsManager.CheckedLeaderboard();

        highScoresCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;

        previousCanvas = currentCanvas;
        currentCanvas = highScoresCanvas;

        player.GetComponent<Leaderboard>().PressedLeaderboardButton();
    }

    public void PressedBackButton()
    {
        currentCanvas.enabled = false;
        previousCanvas.enabled = true;

        currentCanvas = previousCanvas;
    }

    public void PlayerDied()
    {
        Time.timeScale = 0;
        if(gameOverCanvas != null)
        {
            gameOverCanvas.enabled = true;
            pauseCanvas.enabled = false;
            pauseButton.enabled = false;

            currentCanvas = gameOverCanvas;
            previousCanvas = null;
        }
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
