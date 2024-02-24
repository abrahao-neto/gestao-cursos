using ApiGestaoCursos.Domain.Entities;

namespace ApiGestaoCursos.Domain.Interfaces.Services
{
    public interface ICursoDomainService
    {
        void Cadastrar(Curso curso);
        void Update(Curso curso);
        void Delete(Curso curso);
        List<Curso> GetAll();
        Curso Get(Guid? id);
    }
}
