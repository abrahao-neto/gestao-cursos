using ApiGestaoCursos.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoCursos.Infra.Data.Mappings
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("CURSO");

            builder.HasKey(a => a.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.Ativo)
               .HasColumnName("ATIVO");

            builder.Property(c => c.Data_Inicio)
                .HasColumnName("DATA_INICIO")
                .IsRequired();

            builder.Property(c => c.Data_Fim)
                .HasColumnName("DATA_FIM")
                .IsRequired();

            builder.Property(c => c.Data_Criacao)
                .HasColumnName("DATA_CRIACAO")
                .IsRequired();

            builder.Property(c => c.Data_Atualizacao)
                .HasColumnName("DATA_ATUALIZACAO");

        }
    }
}
