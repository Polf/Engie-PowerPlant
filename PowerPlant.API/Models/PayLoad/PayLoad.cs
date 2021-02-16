using System.Collections.Generic;

namespace PowerPlant.API.Models
{
    public class PayLoad
    {
        public PayLoad()
        {
        }

        public float Load { get; set; }

        public IList<Fuel> Fuels { get; set; }


        public IList<GenericPowerPlant> PowerPlants {get;set;}

    }
}
