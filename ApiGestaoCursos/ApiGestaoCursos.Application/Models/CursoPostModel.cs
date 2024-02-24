using System.ComponentModel.DataAnnotations;

namespace ApiGestaoCursos.Application.Models
{
    public class CursoPostModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do curso.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma descrição do curso.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma data de início.")]
        [DataType(DataType.DateTime, ErrorMessage = "A data de início não pode ser maior que a data de fim.")]
        public DateTime? Data_Inicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma data de fim.")]
        public DateTime? Data_Fim { get; set; }
    }
}
