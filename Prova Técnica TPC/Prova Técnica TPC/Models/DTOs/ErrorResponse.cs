namespace ProvaTecnicaTPC.Models.DTOs
{
    public class ErrorResponse
    {
        public int Status { get; set; } = 400;
        public string Descricao { get; set; } = "Mensagem personalizada: Problemas com a sua requsição!";

    }
}
