using System.ComponentModel.DataAnnotations;

namespace ApiGestaoCursos.Application.Models
{
    public class CursoPutModel
    {
        public Guid? Id { get; set; }
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,50}$", ErrorMessage = "Por favor, informe um nome válido com até 50 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do curso.")]
        public string? Nome { get; set; }

        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,200}$", ErrorMessage = "Por favor, informe um nome válido de 6 a 200 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe uma descrição do curso.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma data de início.")]
        [DataType(DataType.DateTime, ErrorMessage = "A data de início não pode ser maior que a data de fim.")]
        public DateTime? Data_Inicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma data de fim.")]
        public DateTime? Data_Fim { get; set; }
        public DateTime Data_Criacao { get; set; }
    }
}
