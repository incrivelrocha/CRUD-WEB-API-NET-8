using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProvaTecnicaTPC.Data.Context;
using ProvaTecnicaTPC.Models.DTOs;
using ProvaTecnicaTPC.Models.Entities;
using ProvaTecnicaTPC.Repositories.Interfaces;

namespace ProvaTecnicaTPC.Repositories.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly MyAppDBContext _context;
        private readonly IMapper _mapper;

        public UsuariosRepository(MyAppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Adicionar(UsuarioDTO adicionarUsuarioDTO)
        {
            UsuarioDTO usuarioDTO = new();

            try
            {
                var usuario = _mapper.Map<UsuariosEntity>(adicionarUsuarioDTO);

                _context.Usuarios.Add(usuario);

                var result = await _context.SaveChangesAsync();

                usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

                return usuarioDTO;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message);
            }

        }

        public async Task<UsuariosListDTO> BuscarPorId(int id)
        {
            UsuariosListDTO usuariosDTOs = new();

            var usuarios = await _context.Usuarios
                .Include(t => t.Tarefas).ThenInclude(s => s.Status)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            usuariosDTOs = _mapper.Map<UsuariosListDTO>(usuarios);

            return usuariosDTOs;

        }

        public async Task<UsuarioDTO> BuscarPorEmail(string email)
        {
            UsuarioDTO usuarioDTO = new();

            var usuarios = await _context.Usuarios
                .Include(t => t.Tarefas).ThenInclude(s => s.Status)
                .Where(x => x.Email.ToLower() == email.ToLower())
                .FirstOrDefaultAsync();

            usuarioDTO = _mapper.Map<UsuarioDTO>(usuarios);

            return usuarioDTO;

        }

        public async Task<IList<UsuariosListDTO>> BuscarTodos()
        {
            IList<UsuariosListDTO> usuariosDTOs =  [new()];
            
            var usuarios = await _context.Usuarios
                .Include(t => t.Tarefas).ThenInclude(s => s.Status)
                .ToListAsync();

            usuariosDTOs = _mapper.Map<IList<UsuariosListDTO>>(usuarios);

            return usuariosDTOs;
        }
    }
}
