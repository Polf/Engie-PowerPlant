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
