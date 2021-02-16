// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System.Collections.Generic;

namespace PowerPlant.API.Converters
{
    public interface IConverter<T,TDto> where T: class, new()
        where TDto : class, new()
    {
        T ToModel(TDto dto);

        TDto ToDto(T model);

        IEnumerable<T> ToModels(IEnumerable<TDto> dtos);


        IEnumerable<TDto> ToDtos(IEnumerable<T> models);
    }
}
