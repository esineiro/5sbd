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
        public async Task<ActionResult<List<Turma>>> BuscarTodasAsTurmas()
        {

            List<Turma> turmas = await _turmaRepositorio.BuscarTodasAsTurmas();
            return Ok(turmas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> BuscarTurmaPorId(int id)
        {
            Turma turma = await _turmaRepositorio.BuscarTurmaPorId(id);
            return Ok(turma);
        }
        [HttpPost]
        public async Task<ActionResult<Turma>> Cadastrar([FromBody] Turma turmaModel)
        {
            Turma turma = await _turmaRepositorio.AdicionarTurma(turmaModel);
            return Ok(turma);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Turma>> Atualizar([FromBody] Turma turmaModel, int id)
        {
            turmaModel.Id = id;
            Turma turma = await _turmaRepositorio.AtualizarTurma(turmaModel, id);
            return Ok(turma);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Turma>> Apagar(int id)
        {
            bool apagada = await _turmaRepositorio.ApagarTurma(id);
            return Ok(apagada);
        }
    }
}
