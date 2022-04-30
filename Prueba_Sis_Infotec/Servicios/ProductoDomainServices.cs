using AutoMapper;
using Prueba_Sis_Infotec.Models;
using Prueba_Sis_Infotec.Models.Response;
using Prueba_Sis_Infotec.Repositorio;

namespace Prueba_Sis_Infotec.Servicios
{
    public class ProductoDomainServices : IProductoDomainServices
    {
        private IProductoRepositorio _productoRepositorio;
        private IMapper _mapper;

        public ProductoDomainServices(IMapper mapper, IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }
        public async Task<ProductoDto> CreateUpdate(ProductoDto productoDto)
        {
            Producto producto = _mapper.Map<ProductoDto, Producto>(productoDto);
            if (producto.Id > 0)
            {
                await _productoRepositorio.Update(producto);
            }
            else
            {
                await _productoRepositorio.Save(producto);
            }

            return _mapper.Map<Producto, ProductoDto>(producto);
            
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Producto producto = await _productoRepositorio.GetById(id);
                if (producto == null) return false;

                await _productoRepositorio.Delete(producto);

                return true;
                
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<ProductoDto>> Get()
        {
            List<Producto> producto = await _productoRepositorio.GetAll();

            return _mapper.Map<List<ProductoDto>>(producto);
        }

        public async Task<ProductoDto> GetById(int id)
        {
            Producto producto = await _productoRepositorio.GetById(id);

            return _mapper.Map<ProductoDto>(producto);
        }
    }
}
