using ProvaTecnicaTPC.Models.DTOs;

namespace ProvaTecnicaTPC.Services.Usuarios
{
    public interface ITarefasService
    {
        Task<TarefasListDTO?> Adicionar(TarefasDTO adicionarUsuariosDTO);
        Task<TarefasListDTO> BuscarPorTitulo(string titulo);
        Task<IList<TarefasListDTO>> BuscarTodos(int id);
    }
}
