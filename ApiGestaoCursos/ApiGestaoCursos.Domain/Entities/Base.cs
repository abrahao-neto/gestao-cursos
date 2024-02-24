namespace ApiGestaoCursos.Domain.Entities
{
    public class Base
    {

        public Guid? Id { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime? Data_Atualizacao { get; set; }
    }
}
