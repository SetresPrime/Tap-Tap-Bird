using UnityEngine;

public class adsManager : MonoBehaviour
{
    string _appKey = "1bbab7f4d";

    private void OnEnable()
    {
        IronSource.Agent.init(_appKey);
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

        IronSource.Agent.loadRewardedVideo();
    }

    void OnApplicationPause(bool isPaused) => IronSource.Agent.onApplicationPause(isPaused);
    private void SdkInitializationCompletedEvent() { Debug.Log("Init : complete"); }

    public void ShowAds()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
            IronSource.Agent.showRewardedVideo();

        else
            Debug.Log("No ADS");
    }
}