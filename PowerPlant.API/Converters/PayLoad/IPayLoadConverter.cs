// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System;
using PowerPlant.API.Dtos;
using PowerPlant.API.Models;

namespace PowerPlant.API.Converters
{
    public interface IPayLoadConverter: IConverter<PayLoad, PayLoadDto>
    {
    }
}
