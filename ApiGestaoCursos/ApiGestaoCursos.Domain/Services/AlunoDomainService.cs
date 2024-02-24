using ApiGestaoCursos.Domain.Entities;
using ApiGestaoCursos.Domain.Interfaces.Repositories;
using ApiGestaoCursos.Domain.Interfaces.Services;

namespace ApiGestaoCursos.Domain.Services
{
    public class AlunoDomainService : IAlunoDomainService
    {

        private readonly IAlunoRepository? _repository;

        public AlunoDomainService(IAlunoRepository? repository)
        {
            _repository = repository;
        }

        public void Cadastrar(Aluno aluno)
        {
            var email = "";
            if (aluno.Email != null)
            {
                email = GetEmail(aluno.Email);
            }

            if (email == null)
                _repository.Post(aluno);
            else
                throw new ArgumentException("Esse email já está cadastrado, tente outro.");
        }

        public void Update(Aluno entity)
        {
            _repository.Put(entity);
        }

        public void Delete(Aluno entity)
        {
            _repository?.Delete(entity);
        }

        public Aluno Get(Guid id)
        {
            return _repository.GetById(id);
        }


        public List<Aluno> GetAll()
        {
            return _repository?.GetAll();
        }

        public List<Aluno> GetAlunos()
        {
            return _repository?.GetAlunos();
        }

        public string GetEmail(string email)
        {
            return _repository.GetEmail(email);
        }

        public Aluno AtivarAluno(Guid id)
        {
            return _repository.AtivaAluno(id);
        }
    }
}
