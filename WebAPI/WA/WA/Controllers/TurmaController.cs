using Microsoft.AspNetCore.Mvc;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepositorio _turmaRepositorio;
        public TurmaController(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<TurmaModel>>> BuscarTodasAsTurmas()
        {

            List<TurmaModel> turmas = await _turmaRepositorio.BuscarTodasAsTurmas();
            return Ok(turmas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TurmaModel>> BuscarTurmaPorId(int id)
        {
            TurmaModel turma = await _turmaRepositorio.BuscarTurmaPorId(id);
            return Ok(turma);
        }
        [HttpPost]
        public async Task<ActionResult<TurmaModel>> Cadastrar([FromBody] TurmaModel turmaModel)
        {
            TurmaModel turma = await _turmaRepositorio.AdicionarTurma(turmaModel);
            return Ok(turma);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TurmaModel>> Atualizar([FromBody] TurmaModel turmaModel, int id)
        {
            turmaModel.Id = id;
            TurmaModel turma = await _turmaRepositorio.AtualizarTurma(turmaModel, id);
            return Ok(turma);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TurmaModel>> Apagar(int id)
        {
            bool apagada = await _turmaRepositorio.ApagarTurma(id);
            return Ok(apagada);
        }
    }
}
