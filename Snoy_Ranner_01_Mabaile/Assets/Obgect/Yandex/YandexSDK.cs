using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;
using System;
using State;

public class YandexSDK : MonoBehaviour
{
    [SerializeField] private StateMashin plaer;
    private Banner banner;
    private Interstitial interstitial;
    
    void Start()
    {
        RequestBanner();
        RequestRewardedAd();
        plaer.svitchStateDaed += ShowInterstitial;
    }

    private void RequestBanner()
    {
        string adUnitId = "R-M-2388670-1";

        AdSize bannerMaxSize = AdSize.FlexibleSize(GetScreenWidthDp(), 50);
        banner = new Banner(adUnitId, bannerMaxSize, AdPosition.BottomCenter);

        banner.OnAdLoaded += HandleAdLoaded;

        this.banner.LoadAd(this.CreateAdRequest());
    }
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }
    public void HandleAdLoaded(object sender, EventArgs args)
    {
        banner.Show();
    }
    private int GetScreenWidthDp()
    {
        int screenWidth = (int)Screen.safeArea.width/2;
        return ScreenUtils.ConvertPixelsToDp(screenWidth);
    }

    private void RequestRewardedAd()
    {
        string adUnitId = "R-M-2388670-2";

        interstitial = new Interstitial(adUnitId);

        this.interstitial.LoadAd(this.CreateAdRequestAllScrin());
    }
    private AdRequest CreateAdRequestAllScrin()
    {
        return new AdRequest.Builder().Build();
    }

    private void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial is not ready yet");
        }
    }
}
