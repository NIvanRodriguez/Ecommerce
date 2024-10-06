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
    public class CategoryService : ICategoryService
    {
        private readonly IGerenicRepository<Category> _modelRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGerenicRepository<Category> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> Crear(CategoryDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Category>(model);
                var rspModel = await _modelRepository.Crear(dbModel);
                if (rspModel.IdCategoria != 0)
                    return new List<CategoryDTO> { _mapper.Map<CategoryDTO>(rspModel) };
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(CategoryDTO model)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdCategoria == model.IdCategoria);
                var fromDbModel = await consulta.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = model.Nombre;
                   
                    var respuesta = await _modelRepository.Editar(fromDbModel);
                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se pudo encontar");
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdCategoria == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    var respuesta = await _modelRepository.Eliminar(fromDbModel);
                    if (!respuesta)
                        throw new TaskCanceledException("Ne se puede eliminar");
                    return respuesta;
                }
                else { throw new TaskCanceledException("No se encontraron resultados"); }

            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<List<CategoryDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p =>
                 p.Nombre.ToLower().Contains(buscar.ToLower()));
                
                List<CategoryDTO> lista = _mapper.Map<List<CategoryDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryDTO>> Obtener(int id)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdCategoria == id);
                var frondDbModel = await consulta.FirstOrDefaultAsync();
                if (frondDbModel != null)
                {
                    return new List<CategoryDTO> { _mapper.Map<CategoryDTO>(frondDbModel) };
                }
                else { throw new TaskCanceledException("No se encontraron coincidencias"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

       
