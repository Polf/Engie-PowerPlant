// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
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
