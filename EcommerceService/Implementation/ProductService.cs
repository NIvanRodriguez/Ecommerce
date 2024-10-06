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
     public class ProductService : IProductService
    { 
        private readonly IGerenicRepository<Producto> _modelRepository;
        private readonly IMapper _mapper;
        public ProductService(IGerenicRepository<Producto> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower()) &&
                p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
                );
                List<ProductDTO> lista = _mapper.Map<List<ProductDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ProductDTO>> Crear(ProductDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Producto>(model);
                var rspModel = await _modelRepository.Crear(dbModel);
                if (rspModel.IdProducto != 0)
                    return new List<ProductDTO> { _mapper.Map<ProductDTO>(rspModel) };
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Editar(ProductDTO model)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdProducto == model.IdProducto);
                var fromDbModel = await consulta.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = model.Nombre;
                    fromDbModel.Descripcion = model.Descripcion;
                    fromDbModel.IdCategoria= model.IdCategoria;
                    fromDbModel.Precio= model.Precio;
                    fromDbModel.PrecioOferta= model.PrecioOferta;
                    fromDbModel.Cantidad= model.Cantidad;
                    fromDbModel.Imagen= model.Imagen;

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
                var consulta = _modelRepository.Consultar(p => p.IdProducto == id);
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

        public async Task<List<ProductDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower()));
                consulta = consulta.Include(c => c.IdCategoriaNavigation);
                List<ProductDTO> lista = _mapper.Map<List<ProductDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> Obtener(int id)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdProducto == id);
                consulta = consulta.Include(c => c.IdCategoriaNavigation);
                var frondDbModel = await consulta.FirstOrDefaultAsync();
                if (frondDbModel != null)
                {
                    return new List<ProductDTO> { _mapper.Map<ProductDTO>(frondDbModel) };
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

