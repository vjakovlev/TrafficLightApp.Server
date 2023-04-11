namespace TrafficLightApp.Services.State
{
    public class RedState : TrafficLightState
    {
        public override TrafficLightState ChangeState(TrafficLightStateManager trafficLightManager)
        {
            trafficLightManager.CurrentState = new RedYellowState();
            return trafficLightManager.CurrentState;
        }
    }
}
