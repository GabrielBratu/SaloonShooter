#if UNITY_ADS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    public void Update()
    {
        if (GameManager.instance.deathCount == 3)
        {
            GameManager.instance.deathCount = 0;
            ShowAd();    
        }
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
#endif