using TrafficLightApp.DomainModels.Enums;
using TrafficLightApp.Repositories.Abstraction;
using TrafficLightApp.Repositories.Implementation;

namespace TrafficLightApp.Services.State
{
    public class TrafficLightStateManager
    {
        protected readonly ITrafficLightRepository _trafficLighRepository;

        private static readonly Lazy<TrafficLightStateManager> _trafficLightStateManager = 
                new Lazy<TrafficLightStateManager>(() => new TrafficLightStateManager());

        public TrafficLightState CurrentState { get; set; }

        public static TrafficLightStateManager Instance 
        {
            get 
            {
                return _trafficLightStateManager.Value;
            }
        }

        private TrafficLightStateManager()
        {
            _trafficLighRepository = new TrafficLightRepository();
            CurrentState = new RedState();
        }

        public void ChangeState()
        {
            TrafficLightState currentState = CurrentState.ChangeState(this);

            if (currentState is RedState) 
            {
                UpdateDatabaseState(LightColor.Red);
            }

            if (currentState is RedYellowState)
            {
                UpdateDatabaseState(LightColor.RedYellow);
            }

            if (currentState is GreenState)
            {
                UpdateDatabaseState(LightColor.Green);
            }

            if (currentState is YellowState)
            {
                UpdateDatabaseState(LightColor.Yellow);
            }

            CurrentState = currentState;
        }

        private void UpdateDatabaseState(LightColor color)
        {
            var trafficLight = _trafficLighRepository.GetTrafficLight();

            foreach (var light in trafficLight.Lights)
            {
                if (light.LightColor == color)
                {
                    light.IsOn = true;
                    continue;
                }

                light.IsOn = false;
            }

            _trafficLighRepository.UpdateTrafficLight(trafficLight);
        }
    }
}
