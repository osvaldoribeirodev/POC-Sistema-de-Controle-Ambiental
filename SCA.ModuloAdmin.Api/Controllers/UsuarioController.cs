using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.ModuloAdmin.Api.Data;
using SCA.ModuloAdmin.Api.Data.Repositories;
using SCA.ModuloAdmin.Api.Models;
using SCA.ModuloAdmin.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;

namespace SCA.ModuloAdmin.Api.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("v1/usuarios")]        
        [Authorize(Roles = "Administrador")]
        public IEnumerable<Usuario> Get()
        {
            string[] includes = { "Perfil" };
            return _usuarioRepository.FindAll(includes);
        }

        [HttpGet]
        [Route("v1/usuarios/{id}")]        
        [Authorize(Roles = "Administrador")]
        public Usuario Get(int id)
        {
            return _usuarioRepository.FindById(id);
        }

        [Route("v1/usuarios")]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult<ResultViewModel> Post([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.Insert(usuario);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Dados salvos com sucesso.",
                    EntityModel = usuario
                };                
            }
            catch (Exception ex)
            {
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ResultViewModel { Success = false, ErrorMessage = (ex.InnerException != null ? ex.InnerException.Message : ex.Message) });
            }            
        }

        [HttpPut]
        [Route("v1/usuarios")]        
        [Authorize(Roles = "Administrador")]
        public ActionResult<ResultViewModel> Put([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.Update(usuario);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Dados atualizados com sucesso.",
                    EntityModel = usuario
                };
            }
            catch (Exception ex)
            {
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ResultViewModel { Success = false, ErrorMessage = (ex.InnerException != null ? ex.InnerException.Message : ex.Message) });
            }
        }

        [HttpPost]
        [Route("v1/usuarios/delete")]        
        [Authorize(Roles = "Administrador")]
        public ActionResult<ResultViewModel> Delete([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.Delete(usuario);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Dados excluídos com sucesso.",
                    EntityModel = usuario
                };
            }
            catch (Exception ex)
            {
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ResultViewModel { Success = false, ErrorMessage = (ex.InnerException != null ? ex.InnerException.Message : ex.Message) });
            }
        }
    }
}
