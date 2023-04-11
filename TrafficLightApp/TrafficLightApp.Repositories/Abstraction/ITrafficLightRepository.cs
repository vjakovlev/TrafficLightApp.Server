using TrafficLightApp.DomainModels.Classes;

namespace TrafficLightApp.Repositories.Abstraction
{
    public interface ITrafficLightRepository
    {
        void UpdateTrafficLight(TrafficLightDomainModel trafficLight);
        TrafficLightDomainModel GetTrafficLight();
    }
}
