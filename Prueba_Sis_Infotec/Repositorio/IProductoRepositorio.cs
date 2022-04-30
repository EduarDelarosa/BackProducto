using Prueba_Sis_Infotec.Models;

namespace Prueba_Sis_Infotec.Repositorio
{
    public interface IProductoRepositorio
    {
        Task<int> Save(Producto producto);
        Task<List<Producto>> GetAll();
        Task<Producto> GetById(int id);
        Task<int> Update(Producto producto);
        Task<int> Delete(Producto producto);
    }
}
