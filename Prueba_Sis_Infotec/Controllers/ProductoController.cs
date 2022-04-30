#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Sis_Infotec.Models;
using Prueba_Sis_Infotec.Models.Response;
using Prueba_Sis_Infotec.Servicios;

namespace Prueba_Sis_Infotec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoDomainServices _productoDomainService;
        private ResponseDto _response;

        public ProductoController(IProductoDomainServices productoDomainServices)
        {
            _productoDomainService = productoDomainServices;
            _response = new ResponseDto();
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            try
            {
                var productos = await _productoDomainService.Get();
                _response.Result = productos;
                _response.DisplayMessage = "Lista De Productos";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _productoDomainService.GetById(id);
            if (producto == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Producto NO Encontrado!";
                return NotFound(_response);
            }

            _response.Result = producto;
            _response.DisplayMessage = "Información del producto";
            return Ok(_response);
        }

        // PUT: api/Producto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(ProductoDto productoDto)
        {
            try
            {
                ProductoDto product = await _productoDomainService.CreateUpdate(productoDto);
                _response.Result = product;
                _response.DisplayMessage = "Información del Producto Actualizado";
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.DisplayMessage = "Error al Actualizar producto";
                return BadRequest(_response);
            }
        }

        // POST: api/Producto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(ProductoDto productoDto)
        {
            try
            {
                ProductoDto product = await _productoDomainService.CreateUpdate(productoDto);
                _response.Result = product;
                return CreatedAtAction("GetProducto", new { id = product.Id } , _response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.DisplayMessage = "Error al crear producto";
                return BadRequest(_response);
            }
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            try
            {
                bool existe = await _productoDomainService.Delete(id);
                if (existe)
                {
                    _response.Result = existe;
                    _response.DisplayMessage = "Producto Eliminado";
                    return Ok(_response);
                }
                else
                {
                    _response.Result = false;
                    _response.DisplayMessage = "Errro al eliminar Producto";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
