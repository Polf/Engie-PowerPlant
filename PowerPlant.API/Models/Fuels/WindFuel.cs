// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
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
