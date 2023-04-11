namespace TrafficLightApp.Services.State
{
    public abstract class TrafficLightState
    {
        public abstract TrafficLightState ChangeState(TrafficLightStateManager trafficLight);       
    }
}
