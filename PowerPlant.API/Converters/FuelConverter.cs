using System.Collections.Generic;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;
using System.Linq;

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

            var co2Price = dto.Fuels.First<KeyValuePair<string, float>>(kv => kv.Key.ToLower().StartsWith("co2")).Value;

            foreach (var f in dto.Fuels) {

                if (f.Key.ToLower().StartsWith("kerosine"))
                    fuels.Add(new KerosineFuel { PricePerMwh = f.Value , Co2PricePerTon = co2Price });

                if (f.Key.ToLower().StartsWith("gas"))
                    fuels.Add(new GasFuel { PricePerMwh = f.Value, Co2PricePerTon = co2Price });

                if (f.Key.ToLower().StartsWith("wind"))
                   fuels.Add(new WindFuel { PricePerMwh = 0 , Co2PricePerTon = co2Price , WindPower = f.Value });

            }

            return fuels;
        }

        public override FuelDto ToDto(List<Fuel> model)
        {
            return new FuelDto();
        }
    }
}
