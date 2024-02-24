namespace ApiGestaoCursos.Domain.Entities
{
    public class Curso : Base
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Data_Inicio { get; set; }
        public DateTime? Data_Fim { get; set; }
        public Boolean Ativo { get; set; }
    }
}
