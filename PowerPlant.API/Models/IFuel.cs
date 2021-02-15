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
