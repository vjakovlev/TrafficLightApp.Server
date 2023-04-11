using TrafficLightApp.DomainModels.Enums;
using TrafficLightApp.Repositories.Abstraction;

namespace TrafficLightApp.Services.State
{
    public class GreenState : TrafficLightState
    {
        public override TrafficLightState ChangeState(TrafficLightStateManager trafficLightManager)
        {
            trafficLightManager.CurrentState = new YellowState();

            return trafficLightManager.CurrentState;
        }
    }
}
