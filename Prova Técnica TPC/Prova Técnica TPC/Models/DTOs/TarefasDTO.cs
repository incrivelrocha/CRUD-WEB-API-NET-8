using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProvaTecnicaTPC.Models.DTOs
{
    public class TarefasDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o ID do usuário para esta tarefa")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o ID de status da tarefa: [1-Pendente, 2-Em Andamento, 3-Concluído]")]
        public int IdStatus { get; set; }

        [Required(ErrorMessage = "Informe o titulo da tarefa")]
        [StringLength(30, ErrorMessage = "O titulo deve conter até 30 caracteres")]
        [MinLength(5, ErrorMessage = "O titulo deve conter o mínimo de 5 caracteres")]
        [DisplayName("Titulo da tarefa")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Informe a descrição da tarefa")]
        [StringLength(30, ErrorMessage = "A descrição deve conter até 30 caracteres")]
        [MinLength(5, ErrorMessage = "A descrição deve conter o mínimo de 5 caracteres")]
        [DisplayName("Descrição da tarefa")]
        public string? DescricaoTarefa { get; set; }
    }
}
