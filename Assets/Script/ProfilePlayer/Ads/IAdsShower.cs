using System;

namespace Tools
{
    public interface IAdsShower
    {
        void ShowInterstitial();
        void ShowVideo(Action successShow);
    }
}

