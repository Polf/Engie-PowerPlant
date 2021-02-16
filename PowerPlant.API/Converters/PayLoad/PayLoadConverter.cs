using System;
using System.Collections.Generic;
using System.Linq;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;

namespace PowerPlant.API.Converters
{
    public class PayLoadConverter : GenericConverter<PayLoad, PayLoadDto>, IPayLoadConverter
    {
        private readonly IPowerPlantConverter _powerPlantConverter;
        private readonly IFuelConverter _fuelConverter;

        public PayLoadConverter(IPowerPlantConverter powerPlantConverter, IFuelConverter fuelConverter)
        {
            _powerPlantConverter = powerPlantConverter;
            _fuelConverter = fuelConverter;
        }

        public override PayLoadDto ToDto(PayLoad model)
        {
            var dto = new PayLoadDto();
            dto.Load = model.Load;
            dto.PowerPlants = _powerPlantConverter.ToDtos(model.PowerPlants).ToArray();
            //dto.Fuels = _fuelConverter.ToDtos()
            return dto;
        }

        public override PayLoad ToModel(PayLoadDto dto)
        {
            var payLoad = new PayLoad();

            payLoad.Load = dto.Load;

            if (dto.PowerPlants == null || !dto.PowerPlants.Any())
                throw new Exception("mandatory field {powerplants} missing and shoud be an array of {powerplant object}");

            var powerPlants = _powerPlantConverter.ToModels(dto.PowerPlants);

            var fuels = _fuelConverter.ToModel(new FuelDto { Fuels = dto.Fuels });

            

            foreach (var p in powerPlants)
            {
                p.Fuel = p switch
                {
                    WindTurbinePowerPlant w => fuels.First(f => f.GetType() == typeof(WindFuel)),
                    GasFiredPowerPlant g => fuels.First(f => f.GetType() == typeof(GasFuel)),
                    _ => fuels.First(f => f.GetType() == typeof(KerosineFuel)),
                };
            }

            payLoad.Fuels = fuels;
            payLoad.PowerPlants = (IList<GenericPowerPlant>)powerPlants;

            return payLoad;

        }
    }
}
