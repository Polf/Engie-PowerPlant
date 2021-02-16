﻿using System;
namespace PowerPlant.API.Models
{
    public class WindTurbinePowerPlant : GenericPowerPlant
    {
        public float WindPercentage { get; set; }

        public WindTurbinePowerPlant()
        {
            Power = (float)Math.Round(WindPercentage * Pmax, 1);
        }

        public WindTurbinePowerPlant(string name, float efficiency, float pmin, float pmax, IFuel fuel, float power) :
         base(name, efficiency, pmin, pmax, fuel, power)
        {


        }

        public override float Power
        {
            get { return (float)Math.Round(WindPercentage * Pmax,1); }
        }

        public override IFuel Fuel
        {
            get => base.Fuel;
            set
            {

                base.Fuel = value;

                if (Fuel is WindFuel)
                    WindPercentage = ((WindFuel)Fuel).WindPower / 100;




            }
        }
    }
}