using ProvaTecnicaTPC.Models.DTOs;
using ProvaTecnicaTPC.Repositories.Interfaces;

namespace ProvaTecnicaTPC.Services.Usuarios
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<UsuarioDTO> Adicionar(UsuarioDTO adicionarUsuarioDTO)
        {
            try
            {
                var validaUsuario = await this.ValidaCadastro(adicionarUsuarioDTO);

                if (validaUsuario != null)
                {
                    return validaUsuario;
                }

                var resultado = await _usuariosRepository.Adicionar(adicionarUsuarioDTO);

                return resultado;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuariosListDTO> BuscarPorId(int id)
        {
            var resultado = await _usuariosRepository.BuscarPorId(id);

            return resultado;
        }

        public async Task<UsuarioDTO> BuscarPorEmail(string email)
        {
            var resultado = await _usuariosRepository.BuscarPorEmail(email);

            return resultado;
        }

        public async Task<IList<UsuariosListDTO>> BuscarTodos()
        {
            var resultado = await _usuariosRepository.BuscarTodos();

            return resultado;
        }

        public async Task<UsuarioDTO?> ValidaCadastro(UsuarioDTO usuario)
        {
            UsuarioDTO validaUsua = new();
            if (usuario.Nome == null || usuario.Nome == "") validaUsua.Nome = "=> O campo Nome é obrigatório! <=";
            if (usuario.Email == null || usuario.Email == "") validaUsua.Email = "=> O campo E-mail é obrigatório! <=";

            if(validaUsua.Nome == null && validaUsua.Email == null)
            {
                var emailExistente = await this.BuscarPorEmail(usuario.Email);
                if (emailExistente != null) 
                {
                    validaUsua = emailExistente;
                    validaUsua.Nome = "=> Já existe um cadastro com este Email! <=";
                    validaUsua.Id = 0;
                }
                else
                {
                    return null;
                }
            }

            return await Task.FromResult(validaUsua);
        }
    }

}
