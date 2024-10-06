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
    public class UserService : IUserService
    {
        private readonly IGerenicRepository<Usuario> _modelRepository;
        private readonly IMapper _mapper;
        public UserService(IGerenicRepository<Usuario> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<SessionDTO>> Autorizacion(LoginDTO model)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.Correo == model.Correo && p.Clave == model.Clave);
                var fromDbModel = await consulta.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    return _mapper.Map<List<SessionDTO>>(fromDbModel);
                }
                else
                    throw new TaskCanceledException("No se encontro coincidencia");

            } catch (Exception ex)
            {
                throw ex;
            }


            //throw new NotImplementedException();
        }

        public IMapper Get_mapper()
        {
            return _mapper;
        }

        public async Task<List<UserDTO>> Crear(UserDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Usuario>(model);
                var rspModel = await _modelRepository.Crear(dbModel);
                if (rspModel.IdUsuario != 0)
                    return new List<UserDTO> { _mapper.Map<UserDTO>(rspModel) };
                else
                    throw new TaskCanceledException("No se puede crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(UserDTO model)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdUsuario == model.IdUsuario);
                var fromDbModel = await consulta.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    fromDbModel.NombreCompleto = model.NombreCompleto;
                    fromDbModel.Correo = model.Correo;
                    fromDbModel.Clave = model.Clave;
                    var respuesta = await _modelRepository.Editar(fromDbModel);
                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se pudo encontar");
                }
            } catch (Exception ex)
            {
                throw ex;
            }
         }
      

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdUsuario == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();
                if(fromDbModel != null)
                {
                    var respuesta = await _modelRepository.Eliminar(fromDbModel);
                    if (!respuesta)
                        throw new TaskCanceledException("Ne se puede eliminar");
                    return respuesta;
                }
                else { throw new TaskCanceledException("No se encontraron resultados"); }

            }
            catch (Exception ex){ throw ex; }
        }

        public async Task<List<UserDTO>> Lista(string rol, string buscar)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p =>
                p.Rol == rol
                && string.Concat(p.NombreCompleto.ToLower(),p.Correo.ToLower()).Contains(buscar.ToLower()));
                List<UserDTO> lista = _mapper.Map<List<UserDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTO>> Obtener(int id)
        {
            try
            {
                var consulta = _modelRepository.Consultar(p => p.IdUsuario == id);
                var frondDbModel = await consulta.FirstOrDefaultAsync();
                if (frondDbModel != null)
                {
                    return new List<UserDTO> { _mapper.Map<UserDTO>(frondDbModel)};
            } else { throw new TaskCanceledException("No se encontraron coincidencias"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
