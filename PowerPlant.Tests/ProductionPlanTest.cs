// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPlant.API.Converters;
using PowerPlant.API.Dtos;
using PowerPlant.API.Services;

namespace PowerPlant.Tests
{
    [TestClass]
    public class ProductionPlanTest
    {
        [TestMethod]
        public void CanComputeLowPlan()
        {
            /****
              setup

             */
            IPowerPlantConverter converter = new PowerPlantConverter();
            IFuelConverter fuelconverter = new FuelConverter();
            IPayLoadConverter payLoadConverter = new PayLoadConverter(converter, fuelconverter);
            var service = new PowerPlantService(converter, payLoadConverter);

            //fuel Dictionnary

            var fuelsDict = new Dictionary<string, float> {
                { "gas(euro/MWh)", 13.4f} ,
                { "kerosine(euro/MWh)", 50.8f},
                { "co2(euro/ton)", 20f},
                { "wind(%)", 60f}
            };

            var pw1 = new PowerPlantInputDto { Name = "gasfirebig1", Type = "gasfired", Efficiency = 0.53f, Pmax = 460, Pmin = 100 };


            var pw2 = new PowerPlantInputDto { Name = "gasfirebig2", Type = "gasfired", Efficiency = 0.53f, Pmax = 460, Pmin = 100 };


            var pw3 = new PowerPlantInputDto { Name = "gasfiredsomewhatsmaller", Type = "gasfired", Efficiency = 0.37f, Pmax = 210, Pmin = 40 };


            var pw4 = new PowerPlantInputDto { Name = "tj1", Type = "turbojet", Efficiency = 0.3f, Pmax = 16, Pmin = 0, };


            var pw5 = new PowerPlantInputDto { Name = "windpark1", Type = "windturbine", Efficiency = 1f, Pmax = 150, Pmin = 0 };


            var pw6 = new PowerPlantInputDto { Name = "windpark2", Type = "windturbine", Efficiency = 1f, Pmax = 36, Pmin = 0 };



            var powerPlants = new List<PowerPlantInputDto> { pw1, pw2, pw3, pw4, pw5, pw6 }.ToArray();


            //3 the payload
            var payload = new PayLoadDto {
                Load = 480,
                Fuels = fuelsDict,
                PowerPlants = powerPlants

            };



            //act

            var result = service.Compute(payload);

            var exceptedResult = new[] {

                new PowerPlantInputDto { Name = "windpark1", Power = 90 },
                new PowerPlantInputDto { Name = "windpark2", Power = 21.6f },
                new PowerPlantInputDto { Name = "gasfirebig1", Power = 368.4f },
                new PowerPlantInputDto { Name = "gasfirebig2", Power = 0 },
                new PowerPlantInputDto { Name = "gasfiredsomewhatsmaller", Power = 0 },
                 new PowerPlantInputDto { Name = "tj1", Power = 0 }


            };

            var hashet = new HashSet<PowerPlantInputDto>(result);

            Assert.IsTrue(hashet.SetEquals(exceptedResult));
        }



        [TestMethod]
        public void CanComputeMediumPlan()
        {
            /****
              setup

             */

            IPowerPlantConverter converter = new PowerPlantConverter();
            IFuelConverter fuelconverter = new FuelConverter();
            IPayLoadConverter payLoadConverter = new PayLoadConverter(converter,fuelconverter);
            var service = new PowerPlantService(converter, payLoadConverter);

            //fuel Dictionnary

            var fuelsDict = new Dictionary<string, float> {
                { "gas(euro/MWh)", 13.4f} ,
                { "kerosine(euro/MWh)", 50.8f},
                { "co2(euro/ton)", 20f},
                { "wind(%)", 60f}
            };


            var pw1 = new PowerPlantInputDto { Name = "gasfirebig1",Type = "gasfired",  Efficiency = 0.53f, Pmax = 460, Pmin = 100 };


            var pw2 = new PowerPlantInputDto { Name = "gasfirebig2",Type = "gasfired" ,  Efficiency = 0.53f, Pmax = 460, Pmin = 100 };


            var pw3 = new PowerPlantInputDto { Name = "gasfiredsomewhatsmaller",  Type= "gasfired" , Efficiency = 0.37f, Pmax = 210, Pmin = 40 };


            var pw4 = new PowerPlantInputDto { Name = "tj1", Type= "turbojet", Efficiency = 0.3f, Pmax = 16, Pmin = 0, };


            var pw5 = new PowerPlantInputDto { Name = "windpark1",Type= "windturbine", Efficiency = 1f, Pmax = 150, Pmin = 0 };


            var pw6 = new PowerPlantInputDto { Name = "windpark2", Type= "windturbine" ,Efficiency = 1f, Pmax = 36, Pmin = 0 };


            var powerPlants = new List<PowerPlantInputDto> { pw1, pw2, pw3, pw4, pw5, pw6 }.ToArray();


            //3 the payload
            var payload = new PayLoadDto
            {
                Load = 580,
                Fuels = fuelsDict,
                PowerPlants = powerPlants

            };


            //act

            var result = service.Compute(payload);

            var exceptedResult = new[] {

                new PowerPlantInputDto { Name = "windpark1", Power = 90 },
                new PowerPlantInputDto { Name = "windpark2", Power = 21.6f },
                new PowerPlantInputDto { Name = "gasfirebig1", Power = 368.4f },
                new PowerPlantInputDto { Name = "gasfirebig2", Power = 100},
                new PowerPlantInputDto { Name = "gasfiredsomewhatsmaller", Power = 0 },
                 new PowerPlantInputDto { Name = "tj1", Power = 0 }


            };

            var hashet = new HashSet<PowerPlantInputDto>(result);

            Assert.IsTrue(hashet.SetEquals(exceptedResult));
        }

        [TestMethod]
        public void CanComputeBigPlan()
        {
            /****
              setup

             */
            IPowerPlantConverter converter = new PowerPlantConverter();
            IFuelConverter fuelconverter = new FuelConverter();
            IPayLoadConverter payLoadConverter = new PayLoadConverter(converter, fuelconverter);
            var service = new PowerPlantService(converter, payLoadConverter);

            //fuel Dictionnary

            var fuelsDict = new Dictionary<string, float> {
                { "gas(euro/MWh)", 13.4f} ,
                { "kerosine(euro/MWh)", 50.8f},
                { "co2(euro/ton)", 20f},
                { "wind(%)", 60f}
            };


            var pw1 = new PowerPlantInputDto { Name = "gasfirebig1", Type = "gasfired", Efficiency = 0.53f, Pmax = 460, Pmin = 100 };


            var pw2 = new PowerPlantInputDto { Name = "gasfirebig2", Type = "gasfired", Efficiency = 0.53f, Pmax = 460, Pmin = 100 };


            var pw3 = new PowerPlantInputDto { Name = "gasfiredsomewhatsmaller", Type = "gasfired", Efficiency = 0.37f, Pmax = 210, Pmin = 40 };


            var pw4 = new PowerPlantInputDto { Name = "tj1", Type = "turbojet", Efficiency = 0.3f, Pmax = 16, Pmin = 0, };


            var pw5 = new PowerPlantInputDto { Name = "windpark1", Type = "windturbine", Efficiency = 1f, Pmax = 150, Pmin = 0 };


            var pw6 = new PowerPlantInputDto { Name = "windpark2", Type = "windturbine", Efficiency = 1f, Pmax = 36, Pmin = 0 };


            var powerPlants = new List<PowerPlantInputDto> { pw1, pw2, pw3, pw4, pw5, pw6 }.ToArray();


            //3 the payload
            var payload = new PayLoadDto
            {
                Load = 910,
                Fuels = fuelsDict,
                PowerPlants = powerPlants

            };


            //act

            var result = service.Compute(payload);

            var exceptedResult = new[] {

                new PowerPlantInputDto { Name = "windpark1", Power = 90 },
                new PowerPlantInputDto { Name = "windpark2", Power = 21.6f},
                new PowerPlantInputDto { Name = "gasfirebig1", Power = 460 },
                new PowerPlantInputDto { Name = "gasfirebig2", Power = 338.4f},
                new PowerPlantInputDto { Name = "gasfiredsomewhatsmaller", Power = 0 },
                 new PowerPlantInputDto { Name = "tj1", Power = 0 }


            };

            var hashet = new HashSet<PowerPlantInputDto>(result);

            Assert.IsTrue(hashet.SetEquals(exceptedResult));
        }


        [TestMethod]
        public void CanComputeSamePriceButDiffrentPminLowPlan()
        {
            /****
              setup

             */
            IPowerPlantConverter converter = new PowerPlantConverter();
            IFuelConverter fuelconverter = new FuelConverter();
            IPayLoadConverter payLoadConverter = new PayLoadConverter(converter, fuelconverter);
            var service = new PowerPlantService(converter, payLoadConverter);

            //fuel Dictionnary

            var fuelsDict = new Dictionary<string, float> {
                { "gas(euro/MWh)", 13.4f} ,
                { "kerosine(euro/MWh)", 50.8f},
                { "co2(euro/ton)", 20f},
                { "wind(%)", 60f}
            };

            var pw1 = new PowerPlantInputDto { Name = "gasfirebig1", Type = "gasfired", Efficiency = 0.53f, Pmax = 460, Pmin = 100 };


            var pw2 = new PowerPlantInputDto { Name = "gasfirebig2", Type = "gasfired", Efficiency = 0.53f, Pmax = 460, Pmin = 100 };


            var pw3 = new PowerPlantInputDto { Name = "gasfiredsomewhatsmaller", Type = "gasfired", Efficiency = 0.53f, Pmax = 210, Pmin = 40 };


            var pw4 = new PowerPlantInputDto { Name = "tj1", Type = "turbojet", Efficiency = 0.3f, Pmax = 16, Pmin = 0, };


            var pw5 = new PowerPlantInputDto { Name = "windpark1", Type = "windturbine", Efficiency = 1f, Pmax = 150, Pmin = 0 };


            var pw6 = new PowerPlantInputDto { Name = "windpark2", Type = "windturbine", Efficiency = 1f, Pmax = 36, Pmin = 0 };



            var powerPlants = new List<PowerPlantInputDto> { pw1, pw2, pw3, pw4, pw5, pw6 }.ToArray();


            //3 the payload
            var payload = new PayLoadDto
            {
                Load = 190,
                Fuels = fuelsDict,
                PowerPlants = powerPlants

            };



            //act

            var result = service.Compute(payload);

            var exceptedResult = new[] {

                new PowerPlantInputDto { Name = "windpark1", Power = 90 },
                new PowerPlantInputDto { Name = "windpark2", Power = 21.6f },
                new PowerPlantInputDto { Name = "gasfirebig1", Power = 0 },
                new PowerPlantInputDto { Name = "gasfirebig2", Power = 0 },
                new PowerPlantInputDto { Name = "gasfiredsomewhatsmaller", Power = 78.4f },
                 new PowerPlantInputDto { Name = "tj1", Power = 0 }


            };

            var hashet = new HashSet<PowerPlantInputDto>(result);

            Assert.IsTrue(hashet.SetEquals(exceptedResult));
        }



    }
}
