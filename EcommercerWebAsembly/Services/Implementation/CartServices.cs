using Blazored.LocalStorage;
using Blazored.Toast.Services;
using EcommerceDTO;
using EcommerceWebAssembly.Services.Contract;
using System.Runtime.CompilerServices;

namespace EcommerceWebAssembly.Services.Implementation
{
    public class CartServices : ICartServices
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastServices;
        public CartServices (ILocalStorageService localStorageService,
        ISyncLocalStorageService syncLocalStorageService,
        IToastService toastServices
            )
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService; 
            _toastServices = toastServices;          
        }

        public event Action ShowItems;

        public async Task AddCart(CartDTO model)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CartDTO>>("carrito");
                if (carrito == null)
                carrito = new List<CartDTO>();

                var encontrado = carrito.FirstOrDefault(c => c.Product.IdProducto == model.Product.IdProducto);

                if (encontrado != null)
                    carrito.Remove(encontrado);

                carrito.Add(model);
                await _localStorageService.SetItemAsync("carrito",carrito);

                if (encontrado != null)
                    _toastServices.ShowSuccess("Producto fue actualizado en carrito");
                else
                    _toastServices.ShowSuccess("Producto fue agregado al carrito");

                ShowItems.Invoke();
            }
            catch
            {
                _toastServices.ShowError("No se pudo agregar al carrito");
            }

        }

        public int AmountProduct()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CartDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count();
        }

        public async Task DeleteCart(int idProduct)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CartDTO>>("carrito");
                if (carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Product.IdProducto == idProduct);
                    if(carrito != null)
                    {
                        carrito.Remove(elemento);
                        await _localStorageService.SetItemAsync("carrito", carrito);
                        ShowItems.Invoke();
                    }

                }
            }
            catch
            {

            }
        }

        public async Task EmptyCart()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            ShowItems.Invoke();
        }

        public async Task<List<CartDTO>> ReturnCart()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CartDTO>>("carrito");
            if (carrito == null)
                carrito = new List<CartDTO>();
            return carrito;
        }
    }
}
