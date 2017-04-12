using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoring : MonoBehaviour
{

    private PlayerMovement playMove;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!playMove.isCircling && playMove.isConnected)
        {
            //Extra points
        }
        else if (playMove.isCircling)
        {
            //Lose points
        }
        else if (playMove.isConnected)
        {
            //points once
        }
    }
}
