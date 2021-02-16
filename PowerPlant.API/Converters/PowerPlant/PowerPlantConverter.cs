// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System;
using PowerPlant.API.Dtos;
using PowerPlant.API.Dtos.PowerPlant;
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
            if (dto.Type == null)
                throw new Exception($"The Power Plant '{ dto.Name }' has not type specified");

            var type = dto.Type.ToLower();

            if (type.StartsWith(PlantType.GASFIRED.ToString().ToLower()))
                return new GasFiredPowerPlant(dto.Name, dto.Efficiency, dto.Pmin, dto.Pmax, null, dto.Pmax);

            else if (type.StartsWith(PlantType.TURBOJET.ToString().ToLower()))
                return new TurbojetPowerPlant(dto.Name, dto.Efficiency, dto.Pmin, dto.Pmax, null, dto.Pmax);

            else if (type.StartsWith(PlantType.WINDTURBINE.ToString().ToLower()))
                return new WindTurbinePowerPlant(dto.Name, dto.Efficiency, dto.Pmin, dto.Pmax, null, dto.Pmax);
            else
                throw new Exception($"Unkown Power Plant type '{dto.Type}' ," +
                    $" possible values are : '{string.Join("|", Enum.GetNames(typeof(PlantType))).ToLower()}'");
        }
    }
}
