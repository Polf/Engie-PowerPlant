namespace PowerPlant.API.Models
{
    public class GasFiredPowerPlant : GenericPowerPlant
    {
        public GasFiredPowerPlant()
        {

        }

        public GasFiredPowerPlant(string name, float efficiency, float pmin, float pmax, IFuel fuel, float power) :
            base(name, efficiency, pmin, pmax, fuel, power)
        { 
      
  
        }





    }
}
