namespace ApiGestaoCursos.Application.Models
{
    public class AlunoGetModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string? Email { get; set; }
        public Boolean Ativo { get; set; }
        public CursoGetModel? Curso { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime? Data_Atualizacao { get; set; }
    }
}
