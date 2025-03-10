using Newtonsoft.Json;

namespace ProvaTecnicaTPC.Models.DTOs
{
    public class UsuariosListDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public List<TarefasListDTO>? Tarefas { get; set; }

    }
}
