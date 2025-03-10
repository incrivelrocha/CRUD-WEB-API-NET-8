using ProvaTecnicaTPC.Models.DTOs;
using ProvaTecnicaTPC.Repositories.Interfaces;

namespace ProvaTecnicaTPC.Services.Usuarios
{
    public class TarefasService : ITarefasService
    {

        private readonly ITarefasRepository _tarefasRepository;

        public TarefasService(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        public async Task<TarefasListDTO?> Adicionar(TarefasDTO adicionarTarefasDTO)
        {
            try
            {
                var resultado = await _tarefasRepository.Adicionar(adicionarTarefasDTO);

                return resultado != null ? (TarefasListDTO)resultado : null;
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message);
            }

        }

        public async Task<TarefasListDTO> BuscarPorTitulo(string titulo)
        {
            var resultado = await _tarefasRepository.BuscarPorTitulo(titulo);

            return resultado;

        }

        public async Task<IList<TarefasListDTO>> BuscarTodos(int id)
        {
            var resultado = await _tarefasRepository.BuscarTodos(id);

            return resultado;
        }
    }
}
