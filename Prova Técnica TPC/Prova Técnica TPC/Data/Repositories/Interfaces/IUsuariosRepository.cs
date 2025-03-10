using ProvaTecnicaTPC.Models.DTOs;

namespace ProvaTecnicaTPC.Repositories.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<UsuarioDTO> Adicionar(UsuarioDTO adicionarUsuariosDTO);
        Task<UsuariosListDTO> BuscarPorId(int id);
        Task<IList<UsuariosListDTO>> BuscarTodos();
        Task<UsuarioDTO> BuscarPorEmail(string email);
    }
}
