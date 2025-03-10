namespace ProvaTecnicaTPC.Models.Entities
{
    public class UsuariosEntity
    {

        public UsuariosEntity() { }

        public UsuariosEntity(int id, string nome, string email)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
        }


        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public List<TarefasEntity>? Tarefas { get; set; }

    }
}
