using SCA.ModuloAdmin.Api.Models;

namespace SCA.ModuloAdmin.Api.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(DataContext dataContext)
            : base(dataContext)
        {

        }
    }
}
