using ApiGestaoCursos.Application.Models;
using ApiGestaoCursos.Domain.Entities;
using AutoMapper;

namespace ApiGestaoCursos.Application.Mappings
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<Aluno, AlunoGetModel>();
            CreateMap<Curso, CursoGetModel>();
        }
    }
}
