using Microsoft.AspNetCore.Mvc;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaRepositorio _disciplinaRepositorio;
        public DisciplinaController(IDisciplinaRepositorio disciplinaRepositorio)
        {
            _disciplinaRepositorio = disciplinaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<DisciplinaModel>>> BuscarTodasAsDisciplinas()
        {
            List<DisciplinaModel> disciplinas = await _disciplinaRepositorio.BuscarTodasAsDisciplinas();
            return Ok(disciplinas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaModel>> BuscarDisciplinaPorId(int id)
        {
            DisciplinaModel disciplina = await _disciplinaRepositorio.BuscarDisciplinaPorId(id);
            return Ok(disciplina);
        }
        [HttpPost]
        public async Task<ActionResult<DisciplinaModel>> Cadastrar([FromBody] DisciplinaModel disciplinaModel)
        {
            DisciplinaModel disciplina = await _disciplinaRepositorio.AdicionarDisciplina(disciplinaModel);
            return Ok(disciplina);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DisciplinaModel>> Atualizar([FromBody] DisciplinaModel disciplinaModel, int id)
        {
            disciplinaModel.Id = id;
            DisciplinaModel disciplina = await _disciplinaRepositorio.AtualizarDisciplina(disciplinaModel, id);
            return Ok(disciplina);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<DisciplinaModel>> Apagar(int id)
        {
            bool apagada = await _disciplinaRepositorio.ApagarDisciplina(id);
            return Ok(apagada);
        }
    }
}
