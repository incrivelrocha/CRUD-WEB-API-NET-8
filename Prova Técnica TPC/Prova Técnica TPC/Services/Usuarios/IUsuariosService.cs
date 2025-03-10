using ProvaTecnicaTPC.Models.DTOs;

namespace ProvaTecnicaTPC.Services.Usuarios
{
    public interface IUsuariosService
    {
        Task<UsuarioDTO> Adicionar(UsuarioDTO adicionarUsuariosDTO);
        Task<UsuariosListDTO> BuscarPorId(int id);
        Task<IList<UsuariosListDTO>> BuscarTodos();
        Task<UsuarioDTO?> ValidaCadastro(UsuarioDTO usuario);
    }
}
