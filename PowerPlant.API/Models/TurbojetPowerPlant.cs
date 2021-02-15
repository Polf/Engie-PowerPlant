namespace PowerPlant.API.Models
{
    public class TurbojetPowerPlant : GenericPowerPlant
    {
        public TurbojetPowerPlant()
        {
        }

        public TurbojetPowerPlant(string name, float efficiency, float pmin, float pmax, IFuel fuel, float power) :
         base(name, efficiency, pmin, pmax, fuel, power)
        {


        }



    }
}
