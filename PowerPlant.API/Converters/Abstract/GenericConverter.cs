// <copyright company="Avengers">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Andry Famantanantsoa OELIHARIVONY</author>
//<email>a.famantanantsoa@gmail.com</>
// <date>16/02/2021 09:15:00 AM </date>
using System;
using System.Collections.Generic;

namespace PowerPlant.API.Converters
{
    public abstract class GenericConverter<T, TDto> : IConverter<T, TDto>
        where T : class, new()
        where TDto : class, new()
     {
        public abstract TDto ToDto(T model);
       

        public virtual IEnumerable<TDto> ToDtos(IEnumerable<T> models)
        {
            List<TDto> dtos = new List<TDto>();

            foreach (var m in models)
                dtos.Add(ToDto(m));

            return dtos.ToArray();
        }

        public abstract T ToModel(TDto dto);
  

        public virtual IEnumerable<T> ToModels(IEnumerable<TDto> dtos)
        {
            List<T> models = new List<T>();
            foreach (var d in dtos)
                models.Add(ToModel(d));
            return models.ToArray();
        }
    }
}
