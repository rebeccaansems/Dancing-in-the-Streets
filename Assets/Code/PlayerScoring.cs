using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoring : MonoBehaviour
{
    public Text scoreText, multiplierText;
    public Image scoreStar;
    public int score;

    private PlayerMovement playMove;
    private int pointsPerScore = 1, highestMultiplier = 1;
    private bool didScore = false, didMultiply = false;

    void Start()
    {
        playMove = GetComponent<PlayerMovement>();
        scoreStar.enabled = false;
        AnalyticsManager.StartedGame();
    }

    void Update()
    {
        if (score > PlayerPrefs.GetInt("Score5") && !scoreStar.enabled)
        {
            scoreStar.enabled = true;
        }
        else if (score <= PlayerPrefs.GetInt("Score5") && scoreStar.enabled)
        {
            scoreStar.enabled = false;
        }

        scoreText.text = score.ToString();
        multiplierText.text = "x" + pointsPerScore;

        if (!didScore)
        {
            if (!playMove.isCircling && playMove.isConnected)
            {
                pointsPerScore++;
                score += pointsPerScore;
                didScore = true;

                if (highestMultiplier < pointsPerScore)
                {
                    highestMultiplier = pointsPerScore;
                }
            }
            else if (playMove.isConnected)
            {
                score += pointsPerScore;
                didScore = true;
            }
            else if (playMove.isCircling && !didMultiply)
            {
                didMultiply = true;
            }
        }
        else
        {
            if (!playMove.isCircling && !playMove.isConnected)
            {
                didMultiply = false;
                didScore = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        score -= 10;
        if (score < 0)
        {
            score = 0;
        }
        pointsPerScore = 1;
    }

    void OnBecameInvisible()
    {
        if (PlayerPrefs.HasKey("GamesPlayed"))
        {
            PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);

            if (PlayerPrefs.GetInt("GamesPlayed") % 4 == 0)
            {
                Advertisements.ShowAd();
                AnalyticsManager.WatchedAd();
            }
        }
        else
        {
            PlayerPrefs.SetInt("GamesPlayed", 1);
        }
        this.GetComponent<Leaderboard>().AddMultiplier(highestMultiplier);

        AnalyticsManager.FinishedGame(score);
    }
}
