using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCA.ModuloAtivo.Api.Data;
using SCA.ModuloAtivo.Api.Data.Repositories;
using SCA.ModuloAtivo.Api.Models;
using SCA.ModuloAtivo.Api.Services;
using SCA.ModuloAtivo.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SCA.ModuloAtivo.Api.Controllers
{
    public class AtivoController : Controller
    {
        private readonly AtivoRepository _ativoRepository;

        public AtivoController(DataContext context, AtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }

        [HttpGet]
        [Route("v1/ativos")]        
        [Authorize(Roles = "Gestor,Engenheiro,Manutenção")]
        public IEnumerable<Ativo> Get()
        {
            string[] includes = { "Classe" };
            var ativos = _ativoRepository.FindAll(includes);
            return ativos;
        }

        [HttpGet]
        [Route("v1/ativos/{id}")]        
        [Authorize(Roles = "Gestor,Engenheiro,Manutenção")]
        public Ativo Get(int id)
        {
            return _ativoRepository.FindById(id);
        }

        [HttpPost]
        [Route("v1/ativos")]        
        [Authorize(Roles = "Gestor")]
        public ActionResult<ResultViewModel> Post([FromBody] Ativo ativo)
        {
            try
            {
                SistemaAquisicaoService saService = new SistemaAquisicaoService();

                ativo.DataCriacao = DateTime.Now;
                ativo.DataUltimaAtualizacao = DateTime.Now;
                //Realizando a integração com o sistema de Aquisições
                var responseEstoque = saService.PostAtivo(ativo);

                _ativoRepository.Insert(ativo);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Dados salvos com sucesso.",
                    EntityModel = ativo
                };
            }
            catch (Exception ex)
            {
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ResultViewModel { Success = false, ErrorMessage = (ex.InnerException != null ? ex.InnerException.Message : ex.Message) });
            }
        }

        [Route("v1/ativos")]
        [HttpPut]
        [Authorize(Roles = "Gestor,Engenheiro,Manutenção")]
        public ActionResult<ResultViewModel> Put([FromBody] Ativo ativo)
        {
            try
            {
                ativo.DataUltimaAtualizacao = DateTime.Now;
                _ativoRepository.Update(ativo);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Dados atualizados com sucesso.",
                    EntityModel = ativo
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
        [Route("v1/ativos/delete")]        
        [Authorize(Roles = "Gestor")]
        public ActionResult<ResultViewModel> Delete([FromBody] Ativo ativo)
        {
            try
            {
                _ativoRepository.Delete(ativo);

                return new ResultViewModel
                {
                    Success = true,
                    Message = "Dados excluídos com sucesso.",
                    EntityModel = ativo
                };
            }
            catch (Exception ex)
            {
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ResultViewModel { Success = false, ErrorMessage = (ex.InnerException != null ? ex.InnerException.Message : ex.Message) });
            }
        }

        //[Route("v1/ativos")]
        //[HttpDelete]
        //public Ativo Delete([FromBody] Ativo ativo)
        //{
        //    _context.Ativos.Remove(ativo);
        //    _context.SaveChanges();

        //    return ativo;
        //}
    }
}
