namespace TrafficLightApp.Services.State
{
    public class RedYellowState : TrafficLightState
    {
        public override TrafficLightState ChangeState(TrafficLightStateManager trafficLightManager)
        {
            trafficLightManager.CurrentState = new GreenState();
            return trafficLightManager.CurrentState;
        }
    }
}
