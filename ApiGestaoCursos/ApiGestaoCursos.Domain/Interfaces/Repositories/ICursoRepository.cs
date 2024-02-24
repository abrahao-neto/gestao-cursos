using ApiGestaoCursos.Domain.Entities;

namespace ApiGestaoCursos.Domain.Interfaces.Repositories
{
    public interface ICursoRepository : IBaseRepository<Curso>
    {
        //Curso AtivaCurso(Guid id, bool ativo);
    }
}
