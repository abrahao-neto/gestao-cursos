using ApiGestaoCursos.Application.interfaces.Services;
using ApiGestaoCursos.Application.Services;
using ApiGestaoCursos.Domain.Interfaces.Repositories;
using ApiGestaoCursos.Domain.Interfaces.Services;
using ApiGestaoCursos.Domain.Services;
using ApiGestaoCursos.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ApiGestaoCursos.Infra.CrossCutting.Ioc
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IAlunoAppService, AlunoAppService>();
            services.AddTransient<IAlunoDomainService, AlunoDomainService>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();

            services.AddTransient<ICursoAppService, CursoAppService>();
            services.AddTransient<ICursoDomainService, CursoDomainService>();
            services.AddTransient<ICursoRepository, CursoRepository>();

            //#region Carga de dados na entidade Categoria

            //using (var dataContext = new DataContext())
            //{
            //    dataContext.Add(new Categoria { Id = Guid.NewGuid(), Nome = "TRABALHO", Descricao = "Tarefas de trabalho." });
            //    dataContext.Add(new Categoria { Id = Guid.NewGuid(), Nome = "FAMÍLIA", Descricao = "Tarefas de família." });
            //    dataContext.Add(new Categoria { Id = Guid.NewGuid(), Nome = "AMIGOS", Descricao = "Tarefas de amigos." });
            //    dataContext.Add(new Categoria { Id = Guid.NewGuid(), Nome = "LAZER", Descricao = "Tarefas de lazer." });
            //    dataContext.Add(new Categoria { Id = Guid.NewGuid(), Nome = "OUTROS", Descricao = "Tarefas gerais." });
            //    dataContext.SaveChanges();
            //}

            //#endregion
        }
    }
}
