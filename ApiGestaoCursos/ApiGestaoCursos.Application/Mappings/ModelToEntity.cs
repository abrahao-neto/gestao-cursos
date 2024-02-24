using ApiGestaoCursos.Application.Models;
using ApiGestaoCursos.Domain.Entities;
using AutoMapper;

namespace ApiGestaoCursos.Application.Mappings
{
    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<AlunoPostModel, Aluno>()
                .AfterMap((model, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.Data_Criacao = DateTime.Now;
                    entity.Data_Atualizacao = DateTime.Now;
                }).ForMember(dest => dest.CursoId, opt => opt.MapFrom(src => src.CursoId));

            CreateMap<AlunoPutModel, Aluno>()
               .AfterMap((model, entity) =>
               {
                   entity.Id = model.Id;
                   entity.Data_Criacao = model.Data_Criacao;
                   entity.Data_Atualizacao = DateTime.Now;
               });

            CreateMap<AlunoGetModel, Aluno>();

            CreateMap<CursoPostModel, Curso>()
                .AfterMap((model, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.Data_Criacao = DateTime.Now;
                    entity.Data_Atualizacao = DateTime.Now;
                });

            CreateMap<CursoPutModel, Curso>()
               .AfterMap((model, entity) =>
               {
                   entity.Id = model.Id;
                   entity.Data_Criacao = model.Data_Criacao;
                   entity.Data_Atualizacao = DateTime.Now;
               });

            CreateMap<CursoGetModel, Curso>();
        }

    }
}
