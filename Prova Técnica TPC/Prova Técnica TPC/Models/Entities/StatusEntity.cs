namespace ProvaTecnicaTPC.Models.Entities
{
    public class StatusEntity
    {

        public StatusEntity(){ }

        public StatusEntity(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public int Id { get; set; }
        public string? Descricao { get; set; }

    }
}
