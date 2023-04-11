using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightApp.DomainModels.Enums;

namespace TrafficLightApp.DomainModels.Classes
{
    public class LightDomainModel
    {
        public LightColor LightColor { get; set; }
        public bool IsOn { get; set; }
        public int Duration { get; set; }
    }
}
