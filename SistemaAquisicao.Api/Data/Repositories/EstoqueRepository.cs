using SistemaAquisicao.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAquisicao.Api.Data.Repositories
{
    public class EstoqueRepository : BaseRepository<Estoque>
    {
        public EstoqueRepository(DataContext context)
            : base(context)
        {

        }
    }
}
