// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
namespace PowerPlant.API.Models
{
    public interface IPowerPlant
    {
        string Name { get; set; }

        float Efficiency { get; set; }

        float Pmin { get; set; }

        float Pmax { get; set; }

        IFuel Fuel { get; set; }

        float Power { get; set; }

        float ComputeTotalPrice();

        float ComputePricePerMwh();

    }
}
