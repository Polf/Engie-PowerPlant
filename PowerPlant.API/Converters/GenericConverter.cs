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
