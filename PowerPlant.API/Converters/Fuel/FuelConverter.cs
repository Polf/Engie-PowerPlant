using System.Collections.Generic;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;
using System.Linq;
using PowerPlant.API.Dtos.Fuel;
using System;

namespace PowerPlant.API.Converters
{
    public class FuelConverter: GenericConverter<List<Fuel>, FuelDto>, IFuelConverter
    {
        public FuelConverter()
        {

        }

        public override List<Fuel> ToModel(FuelDto dto)
        {
            List<Fuel> fuels = new List<Fuel>();

            if (dto.Fuels == null || !dto.Fuels.Any())
                throw new System.Exception("No params '{fuels}' in the payload , and it should an array of {key : string ,value : number}");

            var co2Price = 0f;
            try
            {
                co2Price = dto.Fuels.First<KeyValuePair<string, float>>(kv => kv.Key.ToLower().StartsWith(FuelParams.CO2)).Value;
            }
            catch 
            {
                throw new System.Exception($"mandatory params '{FuelParams.CO2}' missing in the fuels");
            }
            
         
            foreach (var f in dto.Fuels.Where(f=> !f.Key.StartsWith(FuelParams.CO2))) {

                if (f.Key.ToLower().StartsWith(FuelType.KEROSINE.ToString().ToLower()))
                    fuels.Add(new KerosineFuel { PricePerMwh = f.Value , Co2PricePerTon = co2Price });

                else if (f.Key.ToLower().StartsWith(FuelType.GAS.ToString().ToLower()))
                    fuels.Add(new GasFuel { PricePerMwh = f.Value, Co2PricePerTon = co2Price, Co2EmmittedPerMwh = FuelParams.CO2_GAS_PER_MWH });

                else if (f.Key.ToLower().StartsWith(FuelType.WIND.ToString().ToLower()))
                    fuels.Add(new WindFuel { PricePerMwh = 0, Co2PricePerTon = co2Price, WindPower = f.Value });

                else
                {
                    throw new System.Exception($"Unknown Fuel Type '{f.Key}' , " +
                       $"possible value are '{string.Join("|", Enum.GetNames(typeof(FuelType))).ToLower()}' ");
                    

                }


            }

            return fuels;
        }

        public override FuelDto ToDto(List<Fuel> model)
        {
            return new FuelDto();
        }
    }
}
