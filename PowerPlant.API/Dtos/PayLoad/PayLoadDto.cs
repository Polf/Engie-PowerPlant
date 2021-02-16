// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System.Collections.Generic;

namespace PowerPlant.API.Dtos
{
    public class PayLoadDto
    {
        public PayLoadDto()
        {
        }

        public float Load { get; set; }

        public Dictionary<string, float> Fuels { get; set; }

        public PowerPlantInputDto [] PowerPlants { get; set; }

     }
}

