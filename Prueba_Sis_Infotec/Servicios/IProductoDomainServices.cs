using Prueba_Sis_Infotec.Models.Response;

namespace Prueba_Sis_Infotec.Servicios
{
    public interface IProductoDomainServices
    {
        Task<List<ProductoDto>> Get();
        Task<ProductoDto> GetById(int id);
        Task<ProductoDto> CreateUpdate(ProductoDto productoDto);
        Task<bool> Delete(int id);
    }
}
