using UnityEngine;

namespace Script.Rewards
{
    public class InstallView
    {
        private DailyRewardController _dailyRewardController;
        private readonly DailyRewardView _dailyRewardView;
        public InstallView(DailyRewardView dailyRewardView)
        {
            _dailyRewardView = dailyRewardView;
            _dailyRewardView.gameObject.SetActive(false);
            _dailyRewardController = new DailyRewardController(_dailyRewardView);
        }
        
        public void ShowRewards()
        {
            _dailyRewardView.gameObject.SetActive(true);
            _dailyRewardController.RefreshView();
        }
    }
}