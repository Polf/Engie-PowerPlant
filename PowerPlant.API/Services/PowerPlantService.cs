using System;
using System.Collections.Generic;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;
using System.Linq;
using PowerPlant.API.Converters;

namespace PowerPlant.API.Services
{
    public class PowerPlantService : IPowerPlantService
    {
        private readonly IPowerPlantConverter _converter;
        private readonly IFuelConverter _fuelconverter;

        public PowerPlantService(IPowerPlantConverter converter, IFuelConverter fuelConverter)
        {
            _converter = converter;
            _fuelconverter = fuelConverter;
        }

        public IEnumerable<PowerPlantInputDto> Compute(PayLoadDto payload)
        {
            var load = payload.Load;

            var powerPlants = _converter.ToModels(payload.PowerPlants);

            var fuels = _fuelconverter.ToModel(new FuelDto { Fuels = payload.Fuels });

            //map fuel to powerplant

            foreach(var p in powerPlants)
            {
                p.Fuel = p switch
                {
                    WindTurbinePowerPlant w => fuels.First(f => f.GetType() == typeof(WindFuel)),
                    GasFiredPowerPlant g => fuels.First(f => f.GetType() == typeof(GasFuel)),
                    _ => fuels.First(f => f.GetType() == typeof(KerosineFuel)),
                };
            }
            

            var powerPlantByMeritOrder = powerPlants.OrderBy(p => p.ComputePricePerMwh());

            return ComputePlan(powerPlantByMeritOrder,load);



        }

        private IEnumerable<PowerPlantInputDto> ComputePlan(IEnumerable<GenericPowerPlant> powerPlants, float load)
        {
            GenericPowerPlant prec = null;
            foreach (var p in powerPlants)
            {

                if (load == 0)
                {
                    p.Power = 0;
                    continue;
                }


                var delta = load - p.Power;

                if (delta == 0)
                {
                    load = 0;
                }

                if (delta > 0)
                {
                    load = delta;
                    prec = p;


                }

                if (delta < 0)
                {


                    var range = Enumerable.Range((int)Math.Floor(p.Pmin), 1 + (int)Math.Floor(p.Power - p.Pmin));
                    var power = range.SingleOrDefault(r => (int)Math.Floor(load) - r == 0);

                     if (power > 0)
                     {
                        p.Power = power;
                        load -= power;
                            
                     }

                    else if (prec != null)
                    {
                        prec.Power -= p.Pmin;
                        p.Power = p.Pmin;
                        prec = null;
                        load = 0;
                    }


                }

               
            }

            var dtos = _converter.ToDtos(powerPlants);

            return dtos;
        }
    }
}
