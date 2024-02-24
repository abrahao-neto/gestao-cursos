using ApiGestaoCursos.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoCursos.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;DataBase=bdgestaocursos;Uid=root;Pwd=1234", new MySqlServerVersion(new Version(8, 0, 23)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
        }
    }
}
