using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoring : MonoBehaviour
{
    public Text scoreText, multiplierText;
    public int score;

    private PlayerMovement playMove;
    private int pointsPerScore = 1, highestMultiplier = 1;
    private bool didScore = false, didMultiply = false;

    void Start()
    {
        playMove = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (score > PlayerPrefs.GetInt("Score5"))
        {
            scoreText.gameObject.GetComponent<Outline>().effectColor = new Color32(236, 45, 61, 255);
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
        this.GetComponent<Leaderboard>().AddMultiplier(highestMultiplier);
    }
}
