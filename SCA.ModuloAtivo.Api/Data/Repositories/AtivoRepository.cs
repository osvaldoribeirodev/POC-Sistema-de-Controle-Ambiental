using SCA.ModuloAtivo.Api.Models;

namespace SCA.ModuloAtivo.Api.Data.Repositories
{
    public class AtivoRepository : BaseRepository<Ativo>
    {
        public AtivoRepository(DataContext context)
            : base(context)
        {
            
        }
    }
}
