using ApiGestaoCursos.Application.Mappings;

namespace ApiGestaoCursos.Services.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void Mapping(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ModelToEntity));
            services.AddAutoMapper(typeof(EntityToModel));
        }
    }
}
