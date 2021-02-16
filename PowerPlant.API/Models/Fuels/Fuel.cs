// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
namespace PowerPlant.API.Models
{
    public class Fuel: IFuel
    {
        public Fuel()
        {

        }

        public float PricePerMwh { get; set; }
        public float Co2EmmittedPerMwh { get; set; }
        public float Co2PricePerTon { get; set; }

        public float
            ComputeTotalPricePerMWh()
        {
            return PricePerMwh + Co2EmmittedPerMwh * Co2PricePerTon;
        }
    }
}
