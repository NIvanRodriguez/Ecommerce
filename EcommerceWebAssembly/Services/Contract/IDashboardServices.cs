using EcommerceDTO;

namespace EcommerceWebAssembly.Services.Contract
{
    public interface IDashboardServices
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();
    }
}
