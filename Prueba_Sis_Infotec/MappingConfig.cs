using AutoMapper;
using Prueba_Sis_Infotec.Models;
using Prueba_Sis_Infotec.Models.Response;

namespace Prueba_Sis_Infotec
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductoDto, Producto>();
                config.CreateMap<Producto, ProductoDto>();
            });
            return mappingConfig;
        }
    }
}
