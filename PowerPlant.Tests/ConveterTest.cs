// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPlant.API.Converters;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;

namespace PowerPlant.Tests
{
    [TestClass]
    public class ConveterTest
    {
        [TestMethod]
        public void CanConvertFuelDtoToModel() {

            //setup
            FuelConverter fuelConverter = new FuelConverter();

            FuelDto dto = new FuelDto { Fuels = new Dictionary<string, float> {
                { "gas(euro/MWh)", 13.4f },
                { "kerosine(euro/MWh)", 50.8f },
                { "co2(euro/ton)", 20f },
                { "wind(%)", 60f } }
            };

            var models = fuelConverter.ToModel(dto);

            var gas = models.Single(f => f.GetType() == typeof(GasFuel));
            float gasPrice = gas.PricePerMwh;
            float co2PriceGaz = gas.Co2PricePerTon;
            Assert.AreEqual(gasPrice , 13.4f);
            Assert.AreEqual(co2PriceGaz,20f);



            Fuel kerosine = models.Single(f => f.GetType() == typeof(KerosineFuel));
            float kerosinePrice = kerosine.PricePerMwh;
            float co2Kerosine = kerosine.Co2PricePerTon;

            Assert.AreEqual(kerosinePrice, 50.8f);
            Assert.AreEqual(co2Kerosine, 20f);

            Fuel wind = models.Single(f => f.GetType() == typeof(WindFuel));
            float windPrice = wind.PricePerMwh;
            float co2Wind = wind.Co2PricePerTon;
            float windPerCentage = ((WindFuel)wind).WindPower;

            Assert.AreEqual(windPrice, 0f);
            Assert.AreEqual(co2Wind, 20f);
            Assert.AreEqual(windPerCentage, 60f);



        }
    

        [TestMethod]
        public void CanConvertFuelModelToDto()
        {
        }

        [TestMethod]
        public void CanConvertPowerPlantDtoToModel()
        {
            // setup
            var powerplantConverter = new PowerPlantConverter();

            PowerPlantInputDto dto = new PowerPlantInputDto { Name ="wind1", Efficiency = 0.58f , Pmin = 0 , Pmax = 150 , Type="windturbine" };

            var model = powerplantConverter.ToModel(dto);

            //act

            Assert.AreEqual(dto.Name, model.Name);
            Assert.AreEqual(dto.Efficiency, model.Efficiency);
            Assert.AreEqual(dto.Pmin, model.Pmin);
            Assert.AreEqual(dto.Pmax, model.Pmax);
            Assert.IsInstanceOfType(model, typeof(WindTurbinePowerPlant));




        }

        [TestMethod]
        public void CanConvertPowerPlantToDto()
        {
            // setup
            var powerplantConverter = new PowerPlantConverter();
            WindTurbinePowerPlant model = new WindTurbinePowerPlant { Name = "wind1", Efficiency = 0.58f, Pmin = 0, Pmax = 150, WindPercentage = 0.60f };
            var dto = powerplantConverter.ToDto(model);
           
            //act

            Assert.AreEqual(dto.Name, model.Name);
            Assert.AreEqual(dto.Power, model.Power);

        }




    }
}
