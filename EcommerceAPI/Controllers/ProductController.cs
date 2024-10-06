using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceService.Contract;
using EcommerceDTO;
using EcommerceService.Implementation;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();
            try
            {
                if (buscar == "NA") buscar = "";

                response.ItsRight = true;
                response.Result = await _productService.Lista(buscar);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }
        [HttpGet("Catalogo/{categoria:alpha}/{buscar:alpha?}")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductDTO>>();
            try
            {
                if (categoria.ToLower() == "todos") categoria = "";
                if (buscar == "NA") buscar = "";

                response.ItsRight = true;
                response.Result = await _productService.Catalogo(categoria, buscar);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }
        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var response = new ResponseDTO<ProductDTO>();
            try
            {
                var productList = await _productService.Obtener(Id);
                var firstproduct = productList.FirstOrDefault();
                if (firstproduct != null)
                    response.ItsRight = true;
                response.Result = firstproduct;
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<List<ProductDTO>>();
            try
            {
                response.ItsRight = true;
                response.Result = await _productService.Crear(model);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductDTO model)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.ItsRight = true;
                response.Result = await _productService.Editar(model);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id )
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.ItsRight = true;
                response.Result = await _productService.Eliminar(Id);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }
    }
}
