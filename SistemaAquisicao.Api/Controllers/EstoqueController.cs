using Microsoft.AspNetCore.Mvc;
using SistemaAquisicao.Api.Data.Repositories;
using SistemaAquisicao.Api.Models;
using SistemaAquisicao.Api.ViewModels;
using System;
using System.Net;

namespace SistemaAquisicao.Api.Controllers
{
    [Route("api/estoques")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueRepository _estoqueRepository;

        public EstoqueController(EstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        [HttpPost]
        [Route("v1")]
        public ActionResult<ResultViewModel> Post([FromBody] Estoque estoque)
        {
            estoque.DataCriacao = DateTime.Now;
            _estoqueRepository.Insert(estoque);

            return StatusCode(
                    (int)HttpStatusCode.Created,
                    new ResultViewModel
                    {
                        Success = true,
                        Message = "Dados salvos com sucesso.",
                        EntityModel = estoque
                    });
        }
    }
}
