namespace ApiGestaoCursos.Domain.Entities
{
    public class Aluno : Base
    {
        public string? Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string? Email { get; set; }
        public Guid? CursoId { get; set; }
        public Boolean Ativo { get; set; }
        public Curso? Curso { get; set; }
    }
}
