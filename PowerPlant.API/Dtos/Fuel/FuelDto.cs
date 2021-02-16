// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System.Collections.Generic;

namespace PowerPlant.API.Dtos
{
    public class FuelDto
    {
        public FuelDto() {
        }

        public FuelDto(Dictionary<string, float> fuels)
        {
            Fuels = fuels;
        }

        public Dictionary<string, float> Fuels { get; set; }

    }
}
