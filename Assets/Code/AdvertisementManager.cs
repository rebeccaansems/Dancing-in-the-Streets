using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementManager : MonoBehaviour
{
    void Start()
    {
#if UNITY_ANDROID
        Advertisement.Initialize("1387878");
#elif UNITY_IOS
        Advertisement.Initialize("1387877");
#endif
    }

    public static void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}

