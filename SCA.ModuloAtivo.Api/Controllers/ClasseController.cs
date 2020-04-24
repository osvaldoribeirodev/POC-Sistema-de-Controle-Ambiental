using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.ModuloAtivo.Api.Data;
using SCA.ModuloAtivo.Api.Data.Repositories;
using SCA.ModuloAtivo.Api.Models;
using System.Collections.Generic;

namespace SCA.ModuloAtivo.Api.Controllers
{
    public class ClasseController : Controller
    {
        //private readonly DataContext _context;
        private readonly ClasseRepository _classeRepository;

        public ClasseController(DataContext context, ClasseRepository classeRepository)
        {
            _classeRepository = classeRepository;
        }

        [HttpGet]
        [Route("v1/classes")]        
        [Authorize(Roles = "Gestor")]
        public IEnumerable<Classe> Get()
        {
            return _classeRepository.FindAll(); //_context.Classes.AsNoTracking().ToList();
        }
    }
}
