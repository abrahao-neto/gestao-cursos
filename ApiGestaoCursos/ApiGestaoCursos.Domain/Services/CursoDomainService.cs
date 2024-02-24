using ApiGestaoCursos.Domain.Entities;
using ApiGestaoCursos.Domain.Interfaces.Repositories;
using ApiGestaoCursos.Domain.Interfaces.Services;

namespace ApiGestaoCursos.Domain.Services
{
    public class CursoDomainService : ICursoDomainService
    {
        private readonly ICursoRepository? _repository;

        public CursoDomainService(ICursoRepository? repository)
        {
            _repository = repository;
        }

        public void Cadastrar(Curso entity)
        {
            _repository.Post(entity);
        }

        public void Update(Curso entity)
        {
            var curso = Get(entity.Id);

            if (curso != null)
                _repository.Put(entity);
            else
                throw new Exception("Curso não encontrado");
        }

        public void Delete(Curso entity)
        {
            _repository.Delete(entity);
        }

        public Curso Get(Guid? id)
        {
            return _repository.GetById(id);
        }

        public List<Curso> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
