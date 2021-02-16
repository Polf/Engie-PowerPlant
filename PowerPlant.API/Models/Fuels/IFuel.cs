// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System;
namespace PowerPlant.API.Models
{
    public interface IFuel
    {
        float Co2EmmittedPerMwh { get; set; }

        float Co2PricePerTon { get; set; }

        float ComputeTotalPricePerMWh();
    }
}
