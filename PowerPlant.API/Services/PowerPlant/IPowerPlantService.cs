using System.Collections.Generic;
using PowerPlant.API.Dtos;

namespace PowerPlant.API.Services
{
    public interface IPowerPlantService
    {
        IEnumerable<PowerPlantInputDto> Compute(PayLoadDto payload);
    }

    
}
