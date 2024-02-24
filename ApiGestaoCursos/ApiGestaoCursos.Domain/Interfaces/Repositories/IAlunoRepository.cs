using ApiGestaoCursos.Domain.Entities;

namespace ApiGestaoCursos.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        string GetEmail(string email);
        List<Aluno> GetAlunos();
        Aluno AtivaAluno(Guid id);
    }
}
