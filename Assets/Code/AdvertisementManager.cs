using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementManager : MonoBehaviour
{
    public static void ShowAd()
    {
        Debug.Log("show");
        if (Advertisement.IsReady())
        {
            Debug.Log("shown");
            Advertisement.Show();
        }
    }
}

