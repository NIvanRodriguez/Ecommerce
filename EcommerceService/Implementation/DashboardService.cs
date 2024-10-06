using AutoMapper;
using EcommerceDTO;
using EcommerceModel;
using EcommerceRepository.Contract;
using EcommerceService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IGerenicRepository<Usuario> _usuarioRepository;
        private readonly IGerenicRepository<Producto> _productoRepository;
        private readonly ISaleRepository  _ventaRepository;
        public DashboardService (
        ISaleRepository ventaRepository,
        IGerenicRepository<Producto> productoRepository,
        IGerenicRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _productoRepository = productoRepository;
            _ventaRepository = ventaRepository; 
        }
         private string Ingresos()
        {
            var consulta = _ventaRepository.Consultar();
            decimal? ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingresos);
        }  
        private int  Ventas()
        {
            var consulta = _ventaRepository.Consultar();
            int total = consulta.Count() ;
            return total;
        } 
        private int  Clientes()
        {
            var consulta = _usuarioRepository.Consultar(u => u.Rol.ToLower() == "cliente");
            int total = consulta.Count() ;
            return total;
        }
        private int Productos()
        {
            var consulta = _productoRepository.Consultar();
            int total = consulta.Count() ;
            return total;
        }
        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                 TotalIncome = Ingresos(),
                 TotalSale = Ventas(),
                 TotalCustomers = Clientes(),
                 TotalProduct = Productos(),
                };
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
