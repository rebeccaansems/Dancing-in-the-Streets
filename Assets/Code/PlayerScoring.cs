using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoring : MonoBehaviour
{
    public Text scoreText;

    private PlayerMovement playMove;
    private int score, pointsPerScore = 1;
    private bool didScore = false, didMultiply = false;

    void Start()
    {
        playMove = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        scoreText.text = score.ToString()+" - Multiplier: "+pointsPerScore;

        if (!didScore)
        {
            if (!playMove.isCircling && playMove.isConnected)
            {
                pointsPerScore++;
                score += pointsPerScore;
                didScore = true;
            }
            else if (playMove.isConnected)
            {
                score += pointsPerScore;
                didScore = true;
            }
            else if (playMove.isCircling && !didMultiply)
            {
                didMultiply = true;
                if (pointsPerScore > 1)
                {
                    pointsPerScore--;
                }
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
}
