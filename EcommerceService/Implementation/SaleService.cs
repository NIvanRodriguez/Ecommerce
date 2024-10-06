using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EcommerceModel;
using EcommerceDTO;
using EcommerceService.Contract;
using AutoMapper;
using EcommerceRepository.Implementation;
using EcommerceRepository.Contract;

namespace EcommerceService.Implementation
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _modelRepository;
        private readonly IMapper _mapper;
        public SaleService(ISaleRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<SaleDTO>> RegistrarVenta(SaleDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Venta>(model);
                var ventasGeneradas = await _modelRepository.Registrar(dbModel);
                if (ventasGeneradas.Idventa == 0)
                    throw new TaskCanceledException("No se puede registrar la venta");
                return new List<SaleDTO> { _mapper.Map<SaleDTO>(ventasGeneradas) };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
