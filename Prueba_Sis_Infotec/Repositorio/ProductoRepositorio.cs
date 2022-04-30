using Microsoft.EntityFrameworkCore;
using Prueba_Sis_Infotec.Models;

namespace Prueba_Sis_Infotec.Repositorio
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly Sistemas_InfotecContext _db;
        public ProductoRepositorio(Sistemas_InfotecContext db)
        {
            _db = db;
        }
        public async Task<int> Delete(Producto producto)
        {
            _db.Productos.Remove(producto);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _db.Productos.ToListAsync();
        }

        public async Task<Producto> GetById(int id)
        {
            return await _db.Productos.FindAsync(id);
        }

        public async Task<int> Save(Producto producto)
        {
            await _db.Productos.AddAsync(producto);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Update(Producto producto)
        {
            _db.Productos.Update(producto);

            return await _db.SaveChangesAsync();
        }
    }
}
