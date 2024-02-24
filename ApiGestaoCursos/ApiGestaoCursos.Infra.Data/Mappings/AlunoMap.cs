using ApiGestaoCursos.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoCursos.Infra.Data.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("ALUNO");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("ID");

            builder.Property(a => a.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Email)
               .HasColumnName("EMAIL")
               .HasMaxLength(80)
               .IsRequired();

            builder.Property(a => a.Ativo)
               .HasColumnName("ATIVO");

            builder.HasIndex(a => a.Email).IsUnique();

            builder.Property(a => a.Data_Nascimento)
                .HasColumnName("DATA_NASCIMENTO")
                .IsRequired();

            builder.Property(c => c.Data_Criacao)
                .HasColumnName("DATA_CRIACAO")
                .IsRequired();

            builder.Property(c => c.Data_Atualizacao)
                .HasColumnName("DATA_ATUALIZACAO");

            builder.HasOne(a => a.Curso)
                .WithMany()
                .HasForeignKey(a => a.CursoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
