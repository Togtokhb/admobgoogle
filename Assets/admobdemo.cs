using UnityEngine;
using System.Collections;
using admob;

public class admobdemo : MonoBehaviour
{
    void Start()
    {
        Debug.Log("start unity demo-------------");
        initAdmob();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log(KeyCode.Escape + "-----------------");
        }
    }

    Admob ad;
    string adBannerId = "ca-app-pub-7055773745553380/1145141811";
    string adInterstitialId = "ca-app-pub-7055773745553380/7691326728";

    void initAdmob()
    {
        ad = Admob.Instance();
        ad.bannerEventHandler += onBannerEvent;
        ad.interstitialEventHandler += onInterstitialEvent;
        ad.rewardedVideoEventHandler += onRewardedVideoEvent;
        ad.nativeBannerEventHandler += onNativeBannerEvent;
        ad.initAdmob(adBannerId, adInterstitialId);//all id are admob test id,change those to your
        ad.setTesting(true);//show test ad
        ad.setGender(AdmobGender.MALE);
        string[] keywords = { "game", "crash", "male game" };
        //  ad.setKeywords(keywords);//set keywords for ad
        Debug.Log("admob inited -------------");

    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(120, 0, 100, 60), "showInterstitial"))
        {

            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial();
            }
        }
        if (GUI.Button(new Rect(240, 0, 130, 60), "showRewardVideo"))
        {

            if (ad.isRewardedVideoReady())
            {
                ad.showRewardedVideo();
            }
            else
            {
                ad.loadRewardedVideo("ca-app-pub-3940256099942544/1712485313");
            }
        }
        if (GUI.Button(new Rect(0, 100, 100, 60), "showbanner"))
        {
            Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.BOTTOM_CENTER, 0);
        }
        if (GUI.Button(new Rect(120, 100, 130, 60), "showbannerABS"))
        {
            Admob.Instance().showBannerAbsolute(AdSize.Banner, 20, 300);
        }
        if (GUI.Button(new Rect(270, 100, 100, 60), "removebanner"))
        {
            Admob.Instance().removeBanner();
        }

        string nativeBannerID = "ca-app-pub-3940256099942544/2934735716";
        if (GUI.Button(new Rect(0, 200, 100, 60), "showNative"))
        {
            Admob.Instance().showNativeBannerRelative(new AdSize(320, 120), AdPosition.BOTTOM_CENTER, 0, nativeBannerID);
        }
        if (GUI.Button(new Rect(120, 200, 130, 60), "showNativeABS"))
        {
            Admob.Instance().showNativeBannerAbsolute(new AdSize(320, 120), 20, 300, nativeBannerID);
        }
        if (GUI.Button(new Rect(270, 200, 100, 60), "removeNative"))
        {
            Admob.Instance().removeNativeBanner();
        }
    }

    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onRewardedVideoEvent---" + eventName + "  rewarded: " + msg);
    }
    void onNativeBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobNativeBannerEvent---" + eventName + "   " + msg);
    }
}
