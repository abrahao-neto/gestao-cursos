using System.ComponentModel.DataAnnotations;

namespace ApiGestaoCursos.Application.Models
{
    public class AlunoPutModel
    {
        public Guid? Id { get; set; }
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,150}$", ErrorMessage = "Por favor, informe um nome válido de 6 a 150 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do aluno.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do aluno.")]
        public DateTime Data_Nascimento { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe um curso.")]
        public Guid? CursoId { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime? Data_Atualizacao { get; set; }
        public Boolean Ativo { get; set; }
    }
}
