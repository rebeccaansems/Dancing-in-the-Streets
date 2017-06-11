using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [Tooltip("Pause: 0, Header: 1, HighScore: 2, GameOver: 3")]
    public Canvas pauseCanvas, headerCanvas, highScoresCanvas, gameOverCanvas, otherApps;
    public Button pauseButton;
    public Slider musicSlider, sfxSlider;
    public GameObject player;

    public static bool isUIOn = false;

    private Canvas currentCanvas, previousCanvas;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        pauseCanvas.enabled = false;
        highScoresCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        otherApps.enabled = false;
        headerCanvas.enabled = true;

        musicSlider.value = PlayerPrefs.HasKey("musicVolume") ? PlayerPrefs.GetFloat("musicVolume") : 0.5f;
        sfxSlider.value = PlayerPrefs.HasKey("sfxVolume") ? PlayerPrefs.GetFloat("sfxVolume") : 0.5f;

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
        PlayerPrefs.SetInt("menuOn", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PressedHighScoresButton()
    {
        AnalyticsManager.CheckedLeaderboard();

        highScoresCanvas.enabled = true;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        otherApps.enabled = false;

        previousCanvas = currentCanvas;
        currentCanvas = highScoresCanvas;

        player.GetComponent<Leaderboard>().PressedLeaderboardButton();
    }

    public void PressedOtherAppsButton()
    {
        otherApps.enabled = true;
        highScoresCanvas.enabled = false;
        pauseCanvas.enabled = false;
        gameOverCanvas.enabled = false;

        previousCanvas = currentCanvas;
        currentCanvas = otherApps;
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
        if (gameOverCanvas != null)
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
        Audio.musicVolume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        Audio.sfxVolume = volume;
    }

    public void RateGameButton()
    {
#if UNITY_IOS
        Application.OpenURL("https://itunes.apple.com/us/app/dancing-in-the-streets/id1233410267?ls=1&mt=8");
#endif
    }

    public void OpenOtherApp(string url)
    {
#if UNITY_IOS
        Application.OpenURL(url);
#endif
    }

    //Dear Code, I do not understand why some letters like float change colour when I type them.; Like Why does public stay blue where bannana stays white - Mergy
}
