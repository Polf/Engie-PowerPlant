using System.Collections.Generic;

namespace PowerPlant.API.Dtos
{
    public class FuelDto
    {
        public FuelDto() {
        }

        public FuelDto(Dictionary<string, float> fuels)
        {
            Fuels = fuels;
        }

        public Dictionary<string, float> Fuels { get; set; }

    }
}
