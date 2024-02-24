namespace ApiGestaoCursos.Application.Models
{
    public class CursoGetModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Data_Inicio { get; set; }
        public DateTime? Data_Fim { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime? Data_Atualizacao { get; set; }
    }
}
