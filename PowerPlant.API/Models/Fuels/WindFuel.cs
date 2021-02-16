namespace PowerPlant.API.Models
{
    public class WindFuel: Fuel
    {
        public float WindPower { get; set; }


        public WindFuel()
        {
            WindPower = 0f;
        }

    }
}
