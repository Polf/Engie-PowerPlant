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
