using ApiGestaoCursos.Domain.Entities;

namespace ApiGestaoCursos.Domain.Interfaces.Services
{
    public interface IAlunoDomainService
    {
        void Cadastrar(Aluno aluno);
        void Update(Aluno aluno);
        void Delete(Aluno aluno);
        List<Aluno> GetAll();
        Aluno Get(Guid id);
        string GetEmail(string email);
        List<Aluno> GetAlunos();

        Aluno AtivarAluno(Guid id);
    }
}
