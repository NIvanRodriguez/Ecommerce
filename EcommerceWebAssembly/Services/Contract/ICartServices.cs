using EcommerceDTO;

namespace EcommerceWebAssembly.Services.Contract
{
    public interface ICartServices
    {
        event Action ShowItems;

        int AmountProduct();
        Task AddCart(CartDTO model);
        Task DeleteCart(int idProduct);
        Task<List<CartDTO>> ReturnCart();
        Task EmptyCart();
    }
}
