using EcommerceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceRepository.Contract
{
    public interface ISaleRepository : IGerenicRepository<Venta>
    {
        Task<Venta> Registrar(Venta model);
    }
}
