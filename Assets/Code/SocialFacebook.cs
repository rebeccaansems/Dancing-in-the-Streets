using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System;

public class SocialFacebook : MonoBehaviour
{
    public string appURL, photoURL;

    void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback);
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void ShareHighScores()
    {
        FB.ShareLink(
        new Uri(appURL),
        "Dancing in the Streets",
        "Try and beat my highscores on Dancing in the Streets!",
        new Uri(photoURL),
        null
        );
    }

    public void ShareNewHighscore()
    {
        FB.ShareLink(
        new Uri(appURL),
        "Dancing in the Streets",
        "My new highscore on Dancing in the Streets is " + PlayerPrefs.GetInt("Score1") + "! Can you beat it?",
        new Uri(photoURL),
        null
        );
    }

    private void InitCallback()
    {
#if !UNITY_EDITOR
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
#endif
    }
}
