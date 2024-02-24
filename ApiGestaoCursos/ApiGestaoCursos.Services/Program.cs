using ApiGestaoCursos.Application.Mappings;
using ApiGestaoCursos.Infra.CrossCutting.Ioc;
using ApiGestaoCursos.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitando o AutoMapper no sistema
AutoMapperConfiguration.Mapping(builder.Services);

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// registrando as injeçoes de denpêndencia
DependencyInjection.Configure(builder.Services);

//Configurar o CORS 
CorsConfiguration.Configure(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//Configurar o CORS 
CorsConfiguration.UseCors(app);

app.MapControllers();

app.Run();

//tornar a classe Program.cs pública..
public partial class Program { }

