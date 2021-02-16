// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System;
namespace PowerPlant.API.Dtos
{
    public class PowerPlantInputDto : IEquatable<PowerPlantInputDto>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public float Efficiency { get; set; }

        public float Pmin { get; set; }

        public float Pmax { get; set; }

        public float Power { get; set; }


        public PowerPlantInputDto()
        {

        }

        public bool Equals(PowerPlantInputDto other)
        {
            return other != null && other.Name.Equals(Name) && other.Power == Power;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Power.GetHashCode();
        }
    }
}
