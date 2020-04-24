
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCA.ModuloAdmin.Api.Authorization;
using SCA.ModuloAdmin.Api.Data;
using SCA.ModuloAdmin.Api.Data.Repositories;
using SCA.ModuloAdmin.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCA.ModuloAdmin.Api.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] Usuario usuario)
        {
            string[] includes = { "Perfil" };
            var usuarioRetorno = _usuarioRepository.Find(includes, x => x.Login == usuario.Login && x.Senha == usuario.Senha); //_context.Usuarios.Include(x => x.Perfil).AsNoTracking().Where(x => x.Login == usuario.Login && x.Senha == usuario.Senha).FirstOrDefault();

            if (usuarioRetorno == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(usuarioRetorno);
            usuarioRetorno.Senha = "";

            return new
            {
                nome = usuarioRetorno.Nome,
                perfil = usuarioRetorno.Perfil.Nome,
                token = token
            };
        }
    }
}
