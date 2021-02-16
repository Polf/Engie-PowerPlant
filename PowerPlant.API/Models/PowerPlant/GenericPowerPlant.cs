// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
namespace PowerPlant.API.Models
{
    public class GenericPowerPlant: IPowerPlant
    {
        public GenericPowerPlant()
        {
            
        }

        public GenericPowerPlant(string name, float efficiency, float pmin, float pmax, IFuel fuel, float power)
        {
            Name = name;
            Efficiency = efficiency;
            Pmin = pmin;
            Pmax = pmax;
            Fuel = fuel;
            Power = power;
        }

        public string Name { get; set; }

        public float Efficiency { get; set; }

        public float Pmin { get; set; }

        public float Pmax { get; set; }

        public virtual IFuel Fuel { get; set; }

        public virtual float Power { get ; set; }


        public virtual float ComputeTotalPrice()
        {

            return Power * ComputePricePerMwh();
        }

        public float ComputePricePerMwh() {
            return Fuel.ComputeTotalPricePerMWh() / Efficiency;
        }
    }
}
