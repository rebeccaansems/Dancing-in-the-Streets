using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementManager : MonoBehaviour
{
    
    void Start()
    {
#if UNITY_ANDROID
        Advertisement.Initialize("1387878", true);
#elif UNITY_IOS
        Advertisement.Initialize("1387877", true);
#endif
    }

    public void ShowAd()
    {
        StartCoroutine("Check");
    }

    IEnumerator Check()
    {
        while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            StopCoroutine("Check");
        }
    }
}

