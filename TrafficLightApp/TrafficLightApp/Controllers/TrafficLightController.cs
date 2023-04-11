using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TrafficLightApp.HubConfig;
using TrafficLightApp.Services.Abstraction;

namespace TrafficLightApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficLightController : ControllerBase
    {
        private readonly IHubContext<TrafficLightHub> _hub;
        private readonly ITrafficLightService _trafficLightService;

        public TrafficLightController(IHubContext<TrafficLightHub> hub, 
                                      ITrafficLightService trafficLightService)
        {
            _hub = hub;
            _trafficLightService = trafficLightService;
        }

        [HttpGet("ActivateHub")]
        public IActionResult ActivateHub() 
        {
            var response = _trafficLightService.GetTrafficLight();
            return Ok(response);
        }


        [HttpGet("GetTrafficLight")]
        public IActionResult GetTrafficLight()
        {
            var result = _trafficLightService.GetTrafficLight();    
            return Ok(result);
        }


        [HttpGet("ChangeState")]
        public async Task<IActionResult> ChangeState()
        {
            _trafficLightService.ChangeState();
            await _hub.Clients.All.SendAsync("trafficlightlistener", _trafficLightService.GetTrafficLight());
            return Ok();
        }
    }
}
