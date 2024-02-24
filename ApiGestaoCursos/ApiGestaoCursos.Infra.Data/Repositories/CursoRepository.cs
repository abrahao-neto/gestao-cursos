using ApiGestaoCursos.Domain.Entities;
using ApiGestaoCursos.Domain.Interfaces.Repositories;

namespace ApiGestaoCursos.Infra.Data.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
    }
}
