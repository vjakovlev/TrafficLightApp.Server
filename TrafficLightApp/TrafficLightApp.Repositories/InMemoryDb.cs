using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightApp.DomainModels.Classes;
using TrafficLightApp.DomainModels.Enums;

namespace TrafficLightApp.Repositories
{
    public static class InMemoryDb
    {
        public static TrafficLightDomainModel TrafficLight = new TrafficLightDomainModel()
        {
            Id = 1,
            IsPedestrianButtonPushed = false,
            Lights = new List<LightDomainModel>
                {
                    new LightDomainModel
                    {
                        LightColor = LightColor.Red,
                        IsOn = true,
                        Duration = 120
                    },
                    new LightDomainModel
                    {
                        LightColor = LightColor.RedYellow,
                        IsOn = false,
                        Duration = 5
                    },
                    new LightDomainModel
                    {
                        LightColor = LightColor.Green,
                        IsOn = false,
                        Duration = 120
                    },
                    new LightDomainModel
                    {
                        LightColor = LightColor.Yellow,
                        IsOn = false,
                        Duration = 5
                    }
                }
        };


    }
}
