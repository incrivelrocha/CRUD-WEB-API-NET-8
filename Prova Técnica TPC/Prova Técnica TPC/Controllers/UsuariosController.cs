using Microsoft.AspNetCore.Mvc;
using ProvaTecnicaTPC.Models.DTOs;
using ProvaTecnicaTPC.Services.Usuarios;

namespace ProvaTecnicaTPC.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosService _usuariosService;
        private readonly ITarefasService _tarefasService;

        public UsuariosController(IUsuariosService usuariosService, ITarefasService tarefasService)
        {
            _usuariosService = usuariosService;
            _tarefasService = tarefasService;
        }


        // POST: api/Cadastros
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioDTO usuariosDto)
        {

            var result = await _usuariosService.Adicionar(usuariosDto);

            return result; 
        }


        // GET: api/Usuarios
        [HttpGet]
        [ProducesResponseType(typeof(IList<UsuariosListDTO>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<IList<UsuariosListDTO>>> GetUsuarioLista()
        {
            try
            {

                var usuarios = await _usuariosService.BuscarTodos();

                return usuarios.Any() ? Ok(usuarios) : BadRequest("Nenhum usuário cadastrado!");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: api/Usuarios/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuariosListDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<UsuariosListDTO>> GetUsuarioPorId(int id)
        {
            var usuariosDTO = await _usuariosService.BuscarPorId(id);

            return Ok(usuariosDTO);
        }

        // POST: api/Usuarios/{id}/tarefas
        [HttpPost("{id}/tarefas")]
        [ProducesResponseType(typeof(TarefasListDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<TarefasListDTO>> PostTarefasPorIdUsuario(TarefasDTO tarefaDto)
        {
            var result = await _tarefasService.Adicionar(tarefaDto);

            return result != null ? (TarefasListDTO)result : BadRequest("Atenção:\nProvavelmente o usuario " + tarefaDto.IdUsuario + " não foi cadastrado ainda. \nO status não pode ser diferente de [1-Pendente, 2-Em Andamento, 3-Concluído]");
        }

        // GET: api/Usuarios/{id}/tarefas
        [HttpGet("{id}/tarefas")]
        public async Task<ActionResult<TarefasListDTO>> GetTarefasPorUsuarios(int id)
        {
            try
            {
                var tarefas = await _tarefasService.BuscarTodos(id);

                return tarefas.Any() ? Ok(tarefas) : BadRequest("Nenhuma tarefa cadastrada para este usuário!");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*private IActionResult Index()
        {
            return View();
        }*/
    }
}
