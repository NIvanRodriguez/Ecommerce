using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EcommerceService.Contract;
using EcommerceDTO;
using EcommerceService.Implementation;
namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    { 
        private readonly IDashboardService _dashboardservice;
        public DashboardController(IDashboardService dashboardservice)
        {

            _dashboardservice = dashboardservice;

        }
        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();
            try
            {

                response.ItsRight = true;
                response.Result = _dashboardservice.Resumen();
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
