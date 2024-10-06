using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EcommerceService.Contract;
using EcommerceDTO;
using EcommerceService.Implementation;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] SaleDTO model)
        {
            var response = new ResponseDTO<List<SaleDTO>>();
            try
            {

                response.ItsRight = true;
                response.Result = await _saleService.RegistrarVenta(model);
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
