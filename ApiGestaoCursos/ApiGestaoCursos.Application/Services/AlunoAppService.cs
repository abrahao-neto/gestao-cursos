using ApiGestaoCursos.Application.interfaces.Services;
using ApiGestaoCursos.Application.Models;
using ApiGestaoCursos.Domain.Entities;
using ApiGestaoCursos.Domain.Interfaces.Services;
using AutoMapper;

namespace ApiGestaoCursos.Application.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IAlunoDomainService? _service;
        private readonly ICursoDomainService? _serviceCurso;
        private readonly IMapper _mapper;


        public AlunoAppService(IAlunoDomainService? service, IMapper mapper, ICursoDomainService? serviceCurso)
        {
            _service = service;
            _mapper = mapper;
            _serviceCurso = serviceCurso;
        }

        public AlunoGetModel Cadastrar(AlunoPostModel model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _service.Cadastrar(aluno);

            return _mapper.Map<AlunoGetModel>(aluno);
        }

        public AlunoGetModel Atualizar(AlunoPutModel model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _service.Update(aluno);

            return getCurso(aluno);
        }

        public AlunoGetModel Excluir(AlunoGetModel model)
        {
            throw new NotImplementedException();
        }

        public List<AlunoGetModel> GetAll()
        {
            var alunos = _service.GetAll();
            return _mapper.Map<List<AlunoGetModel>>(alunos);
        }

        public AlunoGetModel GetById(Guid id)
        {
            var aluno = _service.Get(id);

            return getCurso(aluno);
        }
    

        public List<AlunoGetModel> GetAlunos()
        {
            var alunos = _service.GetAlunos();
            return _mapper.Map<List<AlunoGetModel>>(alunos);
        }

        public AlunoGetModel AtivarAluno(Guid id)
        {
            var aluno = _service.AtivarAluno(id);
            return _mapper.Map<AlunoGetModel>(aluno);
        }

        private AlunoGetModel getCurso(Aluno aluno)
        {
            var alunoModel = _mapper.Map<AlunoGetModel>(aluno);
            var curso = _serviceCurso.Get(aluno.CursoId);

            alunoModel.Curso = new CursoGetModel();
            alunoModel.Curso.Id = curso.Id;
            alunoModel.Curso.Nome = curso.Nome;
            alunoModel.Curso.Descricao = curso.Descricao;
            alunoModel.Curso.Data_Inicio = curso.Data_Inicio;
            alunoModel.Curso.Data_Fim = curso.Data_Fim;
            alunoModel.Curso.Data_Criacao = curso.Data_Criacao;
            alunoModel.Curso.Data_Atualizacao = curso.Data_Atualizacao;

            return alunoModel;
        }
    }
}
