using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using EcommerceRepository.Contract;
using EcommerceRepository.DBContext;
using Microsoft.EntityFrameworkCore;

namespace EcommerceRepository.Implementation
{
    public class GenericRepository<TModel> :IGerenicRepository<TModel> where TModel : class
    {
        private readonly DbecommerceContext _dbContext;
        public GenericRepository(DbecommerceContext dbContext)
        {
       _dbContext = dbContext;
        }

        public IQueryable<TModel> Consultar(Expression<Func<TModel, bool>>? filtro = null)
        {
            IQueryable<TModel> Consulta = (filtro == null) ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filtro);
            return Consulta;
        }

        public async Task<TModel> Crear(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
            //throw new NotImplementedException();
        }
    }
    }
 
