using SCA.ModuloAtivo.Api.Models;

namespace SCA.ModuloAtivo.Api.Data.Repositories
{
    public class ClasseRepository : BaseRepository<Classe>
    {
        public ClasseRepository(DataContext context)
            : base(context)
        {
            
        }        
    }
}
