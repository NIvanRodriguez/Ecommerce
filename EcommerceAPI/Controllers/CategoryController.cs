using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceService.Contract;
using EcommerceDTO;
using EcommerceService.Implementation;
using Microsoft.AspNetCore.Components.Web;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista( string buscar = "NA")
        {
            var response = new ResponseDTO<List<CategoryDTO>>();
            try
            {
                if (buscar == "NA") buscar = "";

                response.ItsRight = true;
                response.Result = await _categoryService.Lista( buscar);
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
            var response = new ResponseDTO<CategoryDTO>();
            try
            {
                var categoryList = await _categoryService.Obtener(Id);
                var firstcategory = categoryList.FirstOrDefault();
                if (firstcategory != null)
                    response.ItsRight = true;
                response.Result = firstcategory;
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<List<CategoryDTO>>();
            try
            {

                response.ItsRight = true;
                response.Result = await _categoryService.Crear(model);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoryDTO model)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.ItsRight = true;
                response.Result = await _categoryService.Editar(model);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.ItsRight = true;
                response.Result = await _categoryService.Eliminar(Id);
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
