using System;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;

namespace PowerPlant.API.Converters
{
    public class PowerPlantConverter : GenericConverter<GenericPowerPlant, PowerPlantInputDto> , IPowerPlantConverter
    {
        public override PowerPlantInputDto ToDto(GenericPowerPlant model)
        {
            return new PowerPlantInputDto { Name = model.Name, Power = model.Power };
        }

        public override GenericPowerPlant ToModel(PowerPlantInputDto dto)
        {
            return (dto.Type.ToLower()) switch
            {
                "gasfired" => new GasFiredPowerPlant(dto.Name, dto.Efficiency, dto.Pmin, dto.Pmax, null, dto.Pmax),
                "turbojet" => new TurbojetPowerPlant(dto.Name, dto.Efficiency, dto.Pmin, dto.Pmax, null, dto.Pmax),
                "windturbine" => new WindTurbinePowerPlant(dto.Name, dto.Efficiency, dto.Pmin, dto.Pmax, null, dto.Pmax),
                _ => throw new Exception("Power Plant type not defined"),
            };
        }
    }
}
