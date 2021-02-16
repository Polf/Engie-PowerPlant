// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System;
using System.Collections.Generic;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;
using System.Linq;
using PowerPlant.API.Converters;

namespace PowerPlant.API.Services
{
    public class PowerPlantService : IPowerPlantService
    {
        private readonly IPowerPlantConverter _converter;
        private readonly IPayLoadConverter _payLoadConverter;

        public PowerPlantService(IPowerPlantConverter converter, IPayLoadConverter payLoadConverter)
        {
            _converter = converter;
            _payLoadConverter = payLoadConverter;
        }

        public IEnumerable<PowerPlantInputDto> Compute(PayLoadDto dto)
        {

            var payload = _payLoadConverter.ToModel(dto);
            
            var powerPlantByMeritOrder = payload.PowerPlants.OrderBy(p => p.ComputePricePerMwh()).ThenBy(p => p.Pmin);

            var load = payload.Load;

            GenericPowerPlant prec = null;

            foreach (var p in powerPlantByMeritOrder)
            {

                if (load == 0)
                {
                    p.Power = 0;
                    continue;
                }


                var delta = load - p.Power;

                if (delta == 0)
                {
                    load = 0;
                }

                if (delta > 0)
                {
                    load = delta;
                    prec = p;


                }

                if (delta < 0)
                {

                    if (load >= p.Pmin && load <= p.Pmax)
                    {
                        p.Power = (float)Math.Round(load, 1);
                        load = 0;

                    }

                    else if (prec != null)
                    {
                        prec.Power = p.Power + load - p.Pmin;
                        p.Power = p.Pmin;
                        prec = null;
                        load = 0;
                    }


                }


            }

            var dtos = _converter.ToDtos(powerPlantByMeritOrder);

            return dtos;
        } 
           
    }
}
