using ProvaTecnicaTPC.Models.DTOs;

namespace ProvaTecnicaTPC.Repositories.Interfaces
{
    public interface ITarefasRepository
    {
        Task<TarefasListDTO?> Adicionar(TarefasDTO adicionarUsuariosDTO);
        Task<TarefasListDTO> BuscarPorTitulo(string titulo);
        Task<IList<TarefasListDTO>> BuscarTodos(int id);
    }
}
