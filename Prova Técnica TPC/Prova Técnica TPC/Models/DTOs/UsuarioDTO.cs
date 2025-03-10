using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProvaTecnicaTPC.Models.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
        [MinLength(5, ErrorMessage = "O nome deve conter o mínimo de 5 caracteres")]
        [DisplayName("Nome completo")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o E-mail")]
        [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
        [MinLength(10, ErrorMessage = "O nome deve conter o mínimo de 10 caracteres")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [DisplayName("Digite o E-mail")]
        public string? Email { get; set; }

    }
}
