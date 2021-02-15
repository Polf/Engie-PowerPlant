using System.Collections.Generic;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;

namespace PowerPlant.API.Converters
{
    public interface IFuelConverter: IConverter<List<Fuel>, FuelDto>
    {

    }
}
