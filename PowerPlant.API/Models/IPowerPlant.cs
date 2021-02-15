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
