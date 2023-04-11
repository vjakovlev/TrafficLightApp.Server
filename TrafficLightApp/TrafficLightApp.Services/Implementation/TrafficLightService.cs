using TrafficLightApp.DomainModels.Enums;
using TrafficLightApp.Repositories.Abstraction;
using TrafficLightApp.Services.Abstraction;
using TrafficLightApp.Services.State;
using TrafficLightApp.ViewModels.Classes;

namespace TrafficLightApp.Services.Implementation
{
    public class TrafficLightService : ITrafficLightService
    {
        private readonly TrafficLightStateManager trafficLightStateManager;
        private readonly ITrafficLightRepository _trafficLightRepository;

        public TrafficLightService(ITrafficLightRepository trafficLightRepository)
        {
            trafficLightStateManager = TrafficLightStateManager.CreateInstance(trafficLightRepository);
            _trafficLightRepository = trafficLightRepository;
        }

        public void ChangeState()
        {
            trafficLightStateManager.ChangeState();
        }

        public TrafficLightViewModel GetTrafficLight()
        {
            var trafficLightFromDb = _trafficLightRepository.GetTrafficLight();

            var activeLight = trafficLightFromDb.Lights.FirstOrDefault(light => light.IsOn);

            var lightViewModel = new LightViewModel
            {
                LightColor = activeLight.LightColor.ToString(),
            };

            if (activeLight.LightColor == LightColor.Red || activeLight.Duration > 5)
            {
                lightViewModel.Duration = activeLight.Duration - 5;
            }
            else 
            {
                lightViewModel.Duration = activeLight.Duration;
            }

            var TrafficLightViewModel = new TrafficLightViewModel()
            {
                ActiveTrafficLight = lightViewModel
            };

            return TrafficLightViewModel;
        }
    }
}
