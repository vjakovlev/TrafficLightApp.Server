using TrafficLightApp.ViewModels.Classes;

namespace TrafficLightApp.Services.Abstraction
{
    public interface ITrafficLightService
    {
        void ChangeState();
        TrafficLightViewModel GetTrafficLight();
    }
}
