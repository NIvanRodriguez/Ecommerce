using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EcommerceService.Contract;
using EcommerceDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string rol, string buscar = "NA")
        {
            var response = new ResponseDTO<List<UserDTO>>();
            try
            {
                if (buscar == "NA") buscar = "";

                response.ItsRight = true;
                response.Result = await _userService.Lista(rol, buscar);
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
            var response = new ResponseDTO<UserDTO>();
            try
            {
                var userList = await _userService.Obtener(Id);
                var firstUser = userList.FirstOrDefault();
                if (firstUser != null)
                    response.ItsRight = true;
                response.Result = firstUser;
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] UserDTO model)
        {
            var response = new ResponseDTO<List<UserDTO>>();
            try
            {

                response.ItsRight = true;
                response.Result = await _userService.Crear(model);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Autorizacion([FromBody] LoginDTO model)
        {
            var response = new ResponseDTO<List<SessionDTO>>();
            try
            {

                response.ItsRight = true;
                response.Result = await _userService.Autorizacion(model);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] UserDTO model)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.ItsRight = true;
                response.Result = await _userService.Editar(model);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Elimimar(int Id)
        {
            var response = new ResponseDTO<bool>();
            try
            {

                response.ItsRight = true;
                response.Result = await _userService.Eliminar(Id);
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
