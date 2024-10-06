using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcommerceDTO;

namespace EcommerceService.Contract
{
  public interface IDashboardService
    {
        DashboardDTO Resumen();
    }
}
