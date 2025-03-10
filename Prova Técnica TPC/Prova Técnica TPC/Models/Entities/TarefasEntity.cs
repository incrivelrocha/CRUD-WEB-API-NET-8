namespace ProvaTecnicaTPC.Models.Entities
{
    public class TarefasEntity
    {


        public TarefasEntity() { }

        public TarefasEntity(int id, string descricaoTarefa, string titulo, int idUsuario, int idStatus)
        {
            this.Id = id;
            this.DescricaoTarefa = descricaoTarefa;
            this.IdUsuario = idUsuario;
            this.IdStatus = idStatus;
            this.Titulo = titulo;
        }



        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdStatus { get; set; }
        public string? Titulo { get; set; }
        public string? DescricaoTarefa { get; set; }

        public StatusEntity? Status { get; set; }

    }
}
