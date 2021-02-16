using System.Collections.Generic;

namespace PowerPlant.API.Dtos
{
    public class PayLoadDto
    {
        public PayLoadDto()
        {
        }

        public float Load { get; set; }

        public Dictionary<string, float> Fuels { get; set; }

        public PowerPlantInputDto [] PowerPlants { get; set; }

     }
}

