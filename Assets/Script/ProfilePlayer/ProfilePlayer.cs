using Profile.Analytic;
using Tools;

namespace Profile
{
    public class ProfilePlayer
    {
        public ProfilePlayer(float speedCar, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = analyticTools;
        }

        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }
        
        public IAnalyticTools AnalyticTools { get; }
    }
}

