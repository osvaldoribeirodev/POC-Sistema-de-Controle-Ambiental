using SCA.ModuloAdmin.Api.Models;

namespace SCA.ModuloAdmin.Api.Data.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>
    {
        public PerfilRepository(DataContext context)
            : base(context)
        {

        }
    }
}
