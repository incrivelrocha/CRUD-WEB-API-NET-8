using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProvaTecnicaTPC.Data.Context;
using ProvaTecnicaTPC.Models.DTOs;
using ProvaTecnicaTPC.Models.Entities;
using ProvaTecnicaTPC.Repositories.Interfaces;
using System.Linq;

namespace ProvaTecnicaTPC.Repositories.Repository
{
    public class TarefasRepository : ITarefasRepository
    {

        private readonly MyAppDBContext _context;
        private readonly IMapper _mapper;
        
        private readonly IUsuariosRepository _usuariosRepository;

        public TarefasRepository(IUsuariosRepository usuariosRepository, MyAppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _usuariosRepository = usuariosRepository;
            using (this.PopularStatus());
        }

        public async Task<TarefasListDTO?> Adicionar(TarefasDTO adicionarTarefasDTO)
        {
            TarefasListDTO tarefasDTO = _mapper.Map<TarefasListDTO>(adicionarTarefasDTO);

            try
            {
                var status = await _context.Status.Where(s => s.Id == adicionarTarefasDTO.IdStatus).AsNoTracking().FirstOrDefaultAsync();
                var usuario = await _context.Usuarios.Where(s => s.Id == adicionarTarefasDTO.IdUsuario).AsNoTracking().FirstOrDefaultAsync();

                if(status == null)
                    return null;
                
                if(usuario == null)
                    return null;
                
                var tarefa = _mapper.Map<TarefasEntity>(tarefasDTO);

                tarefa.Status = null;

                await _context.Tarefas.AddAsync(tarefa);

                var result = await _context.SaveChangesAsync();

                tarefasDTO = _mapper.Map<TarefasListDTO>(tarefa);

                tarefasDTO.Status = _mapper.Map<StatusDTO>(status);

                return tarefasDTO;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message);
            }

        }

        public async Task<TarefasListDTO> BuscarPorTitulo(string titulo)
        {
            TarefasListDTO tarefasDTO;

            var usuarios = await _context.Tarefas
                .Include(t => t.Status)
                .Where(x => x.Titulo.ToLower() == titulo.ToLower())
                .FirstOrDefaultAsync();

            tarefasDTO = _mapper.Map<TarefasListDTO>(usuarios);

            return tarefasDTO;

        }

        public async Task<IList<TarefasListDTO>> BuscarTodos(int id)
        {
            IList<TarefasListDTO> tarefasDTOs = [];
            var tarefas = await _context.Tarefas
                .Include(t => t.Status)
                .Where(x => x.IdUsuario == id)
                .ToListAsync();

            tarefasDTOs = _mapper.Map<IList<TarefasListDTO>>(tarefas);

            return tarefasDTOs;
        }
        
        public async Task PopularStatus()
        {
            var tarefas = await _context.Status.AsNoTracking().ToListAsync();

            if (tarefas.Count == 0) 
            {
                await _context.Status.AddAsync(new StatusEntity(1, "Pendente"));
                await _context.Status.AddAsync(new StatusEntity(2, "Em Andamento"));
                await _context.Status.AddAsync(new StatusEntity(3, "Concluído"));
                await _context.SaveChangesAsync();
            };

            return;
        }
    }
}
