using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceDTO;
using EcommerceModel;

namespace EcommerceUtilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario,UserDTO>();
            CreateMap<Usuario,SessionDTO>();
            CreateMap<UserDTO,Usuario>();

            CreateMap<Category,CategoryDTO>();
            CreateMap<CategoryDTO,Category>();

            CreateMap<Producto,ProductDTO>();
            CreateMap<ProductDTO, Producto>().ForMember(destino =>
            destino.IdCategoriaNavigation,
            opt => opt.Ignore()
            );
            CreateMap<DetalleVenta,SalesDetailDTO>();
            CreateMap<SalesDetailDTO, DetalleVenta>();

            CreateMap<Venta, SaleDTO>();
            CreateMap<SaleDTO, Venta>();
        }
    }
}
