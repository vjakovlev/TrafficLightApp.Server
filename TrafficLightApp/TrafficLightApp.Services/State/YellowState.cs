namespace TrafficLightApp.Services.State
{
    public class YellowState : TrafficLightState
    {
        public override TrafficLightState ChangeState(TrafficLightStateManager trafficLightManager)
        {
            trafficLightManager.CurrentState = new RedState();
            return trafficLightManager.CurrentState;
        }
    }
}
