namespace ProvaTecnicaTPC.Models.DTOs
{
    public class TarefasListDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdStatus { get; set; }
        public string? Titulo { get; set; }
        public string? DescricaoTarefa { get; set; }
        public StatusDTO? Status { get; set; }
    }
}
