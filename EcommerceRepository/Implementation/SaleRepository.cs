﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceModel;
using EcommerceRepository.Contract;
using EcommerceRepository.DBContext;
using Microsoft.EntityFrameworkCore;


namespace EcommerceRepository.Implementation
{
    public class SaleRepository : GenericRepository<Venta>, ISaleRepository
    {
        private readonly DbecommerceContext _dbContext;
        public SaleRepository(DbecommerceContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta model)
        {
            Venta saleGenerated = new Venta();
            
            using(var transaction = _dbContext.Database.BeginTransaction() )
            {
                try
                {
                  foreach(DetalleVenta dv in model.DetalleVenta)
                    {
                        Producto producto_encontrada = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        producto_encontrada.Cantidad = producto_encontrada.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrada);
                    }
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Venta.AddAsync(model);
                    await _dbContext.SaveChangesAsync();
                    saleGenerated = model;
                    transaction.Commit();
                } catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return saleGenerated;
        }
    }
}
