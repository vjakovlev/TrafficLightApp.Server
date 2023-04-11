using TrafficLightApp.DomainModels.Classes;
using TrafficLightApp.Repositories.Abstraction;

namespace TrafficLightApp.Repositories.Implementation
{
    public class TrafficLightRepository : ITrafficLightRepository
    {
        public void UpdateTrafficLight(TrafficLightDomainModel trafficLight)
        {
            InMemoryDb.TrafficLight = trafficLight;
        }

        public TrafficLightDomainModel GetTrafficLight()
        {
            return InMemoryDb.TrafficLight;
        }
    }
}
