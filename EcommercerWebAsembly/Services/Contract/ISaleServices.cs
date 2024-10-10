using EcommerceDTO;

namespace EcommerceWebAssembly.Services.Contract
{
    public interface ISaleServices
    {
        Task<ResponseDTO<SaleDTO>> Registrar(SaleDTO model);
    }
}
