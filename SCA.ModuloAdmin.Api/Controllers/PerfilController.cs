using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCA.ModuloAdmin.Api.Data;
using SCA.ModuloAdmin.Api.Data.Repositories;
using SCA.ModuloAdmin.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace SCA.ModuloAdmin.Api.Controllers
{
    public class PerfilController : Controller
    {
        //private readonly DataContext _context;
        private PerfilRepository _perfilRepository;

        public PerfilController(PerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        [HttpGet]
        [Route("v1/perfis")]
        [Authorize(Roles = "Administrador")]
        public IEnumerable<Perfil> Get()
        {
            return _perfilRepository.FindAll(); //_context.Perfis.AsNoTracking().ToList();
        }
    }
}
