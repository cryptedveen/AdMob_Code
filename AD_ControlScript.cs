using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AD_ControlScript : MonoBehaviour
{

    private BannerView bannerView;
    [SerializeField] float BannerAdWaitTime = 60f;
   

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        StartCoroutine(RefreshBannerAd());
    }

    private void ShowBannerAd()
    {
        RequestBanner();
        LoadBanner();
    }

    IEnumerator RefreshBannerAd()
    {

        ShowBannerAd();
        yield return new WaitForSeconds(BannerAdWaitTime);

        DestroyBanner();

        yield return new WaitForSeconds(5f);

        RestartAd();
    }

    void RestartAd()
    {
        StartCoroutine(RefreshBannerAd());
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4265126177729958/8486686494";
        #elif UNITY_IPHONE
            string adUnitId = "";
        #else
            string adUnitId = "unexpected_platform";
        #endif
    
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
    }

    private void LoadBanner()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    private void DestroyBanner()
    {
        bannerView.Destroy();
    }

    //All Above are Banner AD Functions

}
