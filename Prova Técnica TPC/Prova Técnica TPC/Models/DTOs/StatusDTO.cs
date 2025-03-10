using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProvaTecnicaTPC.Models.DTOs
{
    public class StatusDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a descricao do status.")]
        [StringLength(20, ErrorMessage = "O nome deve conter até 20 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve conter o mínimo de 3 caracteres")]
        [DisplayName("Nome completo")]
        public string? Descricao { get; set; }

    }
}
