// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
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
