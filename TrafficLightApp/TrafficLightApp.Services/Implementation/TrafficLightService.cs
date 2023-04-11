using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Duration = activeLight.Duration,
                LightColor = activeLight.LightColor.ToString(),
            };

            var TrafficLightViewModel = new TrafficLightViewModel()
            {
                ActiveTrafficLight = lightViewModel
            };

            return TrafficLightViewModel;
        }
    }
}
