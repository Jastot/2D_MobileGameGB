using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Tools
{
    public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
    {
        private string _gameId = "1457683";
        private string _rewardPlace = "rewardVideo";
        private string _interstitialPlace = "interstitialAds";

        private Action _callbackSuccessShowVideo;
        
        private void Start()
        {
            Advertisement.Initialize (_gameId, true);
        }
        
        public void ShowInterstitial()
        {
            _callbackSuccessShowVideo = null;
            Advertisement.Show(_interstitialPlace);
        }

        public void ShowVideo(Action successShow)
        {
            _callbackSuccessShowVideo = successShow;
            Advertisement.Show(_rewardPlace);
        }

        public void OnUnityAdsReady(string placementId)
        {
            
        }

        public void OnUnityAdsDidError(string message)
        {
            
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Finished)
                _callbackSuccessShowVideo?.Invoke();
        }
    }
}

