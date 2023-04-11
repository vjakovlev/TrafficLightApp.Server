using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightApp.DomainModels.Enums;

namespace TrafficLightApp.DomainModels.Classes
{
    public class TrafficLightDomainModel
    {
        public int Id { get; set; }
        public List<LightDomainModel> Lights { get; set; }
        public bool IsPedestrianButtonPushed { get; set; }
    }
}
