using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdMob_Initializer : MonoBehaviour
{
    [SerializeField] string appId;
    [SerializeField] Ads_Rewards ads_rewards;

#if UNITY_ANDROID
    string bannerID = "ca-app-pub-3680686492453061/4912790956";
    string interCoinsID = "ca-app-pub-3680686492453061/9229092871";
    string interSkinID = "ca-app-pub-3680686492453061/5100493216";
    string rewardedGemsID = "ca-app-pub-3680686492453061/7590925186";
    string rewardeSkindID = "ca-app-pub-3680686492453061/6688907052";
    string nativeID = "ca-app-pub-3680686492453061/7124021327";
#elif UNITY_IPHONE
    string bannerID = "";
    string interCoinsID = "";
    string interSkinID = "";
    string rewardedGemsID = "";
    string rewardeSkindID = "";
    string nativeID = "";
#endif

    BannerView bannerView;
    InterstitialAd interstitialAd;
    RewardedAd rewardedAd;
    // NativeAd nativeAd;

    private void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus =>
        {
            print($"ADS INITIALISED ! ");
        });
    }

    #region BANNER 
    public void Banner_Load()
    {
        Banner_CreateView();
        Banner_ListenToEvents();

        if (bannerView == null)
            Banner_CreateView();

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        print("LOADING BANNER AD ");
        bannerView.LoadAd(adRequest); // show the banner
    }

    public void Banner_Destroy()
    {
        if (bannerView != null)
        {
            print("DESTROY BANNER AD");
            bannerView.Destroy();
            bannerView = null;
        }
    }

    void Banner_CreateView()
    {
        if (bannerView != null)
            bannerView.Destroy();

        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
    }

    void Banner_ListenToEvents()
    {
        // Raised when an ad is loaded into the banner view.
        bannerView.OnBannerAdLoaded += () =>
        {
            print("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };

        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            print($"{adValue.Value} {adValue.CurrencyCode}");
        };

        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            print("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            print("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            print("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            print("Banner view full screen content closed.");
        };
    }

    #endregion

    #region INTERSTITIAL COINS
    public void Interstitial_Coins_Load()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        InterstitialAd.Load(interCoinsID, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                print($"INTER COINS FAILED TO LOAD ");
                return;
            }

            print($"INTERSTITIAL COINS AD LOADED {ad.GetResponseInfo()}");

            interstitialAd = ad;
            Interstitial_Coins_Event(interstitialAd);

            Interstitial_Coins_Show();
        });
    }

    public void Interstitial_Coins_Show()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
            interstitialAd.Show();
        else
            print($"CANT LOAD INTERSTITAL AD");
    }

    public void Interstitial_Coins_Event(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            print($"{adValue.Value} {adValue.CurrencyCode}");
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            print("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            print("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            print("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            print("Interstitial ad full screen content closed.");
            ads_rewards.Reward_Interstitial_Coins_1();
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion

    #region INTERSTITIAL SKIN
    public void Interstitial_Skin_Load()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        InterstitialAd.Load(interCoinsID, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                print($"INTER COINS FAILED TO LOAD ");
                return;
            }

            print($"INTERSTITIAL COINS AD LOADED {ad.GetResponseInfo()}");

            interstitialAd = ad;
            Interstitial_Skin_Event(interstitialAd);

            Interstitial_Skin_Show();
        });
    }

    public void Interstitial_Skin_Show()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
            interstitialAd.Show();
        else
            print($"CANT LOAD INTERSTITAL AD");
    }

    public void Interstitial_Skin_Event(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            print($"{adValue.Value} {adValue.CurrencyCode}");
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            print("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            print("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            print("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            print("Interstitial ad full screen content closed.");
            ads_rewards.Reward_Interstitial_Skin_1();
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion

    #region REWARDED GEMS
    public void Rewarded_Gems_Load() 
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(rewardedGemsID, adRequest, (RewardedAd ad, LoadAdError error)=>
        {
            if(error != null || ad == null)
            {
                print($"INTER COINS FAILED TO LOAD ");
                return;
            }

            print($"REWARDED GEMS AD LOADED {ad.GetResponseInfo()}");
            rewardedAd = ad;
            Rewarded_Gems_Events(rewardedAd);

            Rewarded_Gems_Show();
        });
    }
    public void Rewarded_Gems_Show()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) => 
            {
                ads_rewards.Reward_Rewarded_Gems_1();
            });
        }
        else
            print("REWARDED AD IS NOT RDY");
    }
    public void Rewarded_Gems_Events(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log($"{adValue.Value} {adValue.CurrencyCode}");
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion

    #region REWARDED SKIN
    public void Rewarded_Skin_Load()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(rewardedGemsID, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                print($"INTER COINS FAILED TO LOAD ");
                return;
            }

            print($"REWARDED GEMS AD LOADED {ad.GetResponseInfo()}");
            rewardedAd = ad;
            Rewarded_Skin_Events(rewardedAd);

            Rewarded_Skin_Show();
        });
    }

    public void Rewarded_Skin_Show()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                ads_rewards.Reward_Rewarded_Skin_2();
            });
        }
        else
            print("REWARDED AD IS NOT RDY");
    }

    public void Rewarded_Skin_Events(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log($"{adValue.Value} {adValue.CurrencyCode}");
        };

        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };

        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };

        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };

        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };

        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion


}