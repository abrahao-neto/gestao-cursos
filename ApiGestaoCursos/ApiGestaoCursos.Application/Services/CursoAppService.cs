using ApiGestaoCursos.Application.interfaces.Services;
using ApiGestaoCursos.Application.Models;
using ApiGestaoCursos.Domain.Entities;
using ApiGestaoCursos.Domain.Interfaces.Services;
using AutoMapper;

namespace ApiGestaoCursos.Application.Services
{
    public class CursoAppService : ICursoAppService
    {
        private readonly ICursoDomainService? _service;
        private readonly IMapper _mapper;

        public CursoAppService(ICursoDomainService? service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public CursoGetModel Cadastrar(CursoPostModel model)
        {
            var curso = _mapper.Map<Curso>(model);
            _service.Cadastrar(curso);

            return _mapper.Map<CursoGetModel>(curso);
        }

        public CursoGetModel Atualizar(CursoPutModel model)
        {
            var curso = _mapper.Map<Curso>(model);
            _service.Update(curso);

            return _mapper.Map<CursoGetModel>(curso);
        }

        public CursoGetModel Excluir(CursoGetModel model)
        {
            throw new NotImplementedException();
        }

        public List<CursoGetModel> GetAll()
        {
            var cursos = _service.GetAll();
            return _mapper.Map<List<CursoGetModel>>(cursos);
        }

        public CursoGetModel GetById(Guid? id)
        {
            var curso = _service.Get(id);

            return _mapper.Map<CursoGetModel>(curso);
        }
    }
}
