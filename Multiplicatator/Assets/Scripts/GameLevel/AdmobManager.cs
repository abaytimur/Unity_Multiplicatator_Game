using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobManager : MonoBehaviour
{
    private BannerView bannerView;

    private string App_ID = "ca-app-pub-8047019804191309~5133154099";
    private string App_AdmodDemo_Banner_ID = "ca-app-pub-3940256099942544/6300978111";
    
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(App_ID);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(App_AdmodDemo_Banner_ID, AdSize.Banner, AdPosition.Top);
        
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void ShowBanner()
    {
        
        bannerView.Show();
        
    }
}