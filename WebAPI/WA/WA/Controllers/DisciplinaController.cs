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
        public async Task<ActionResult<List<Disciplina>>> BuscarTodasAsDisciplinas()
        {
            List<Disciplina> disciplinas = await _disciplinaRepositorio.BuscarTodasAsDisciplinas();
            return Ok(disciplinas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Disciplina>> BuscarDisciplinaPorId(int id)
        {
            Disciplina disciplina = await _disciplinaRepositorio.BuscarDisciplinaPorId(id);
            return Ok(disciplina);
        }
        [HttpPost]
        public async Task<ActionResult<Disciplina>> Cadastrar([FromBody] Disciplina disciplinaModel)
        {
            Disciplina disciplina = await _disciplinaRepositorio.AdicionarDisciplina(disciplinaModel);
            return Ok(disciplina);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Disciplina>> Atualizar([FromBody] Disciplina disciplinaModel, int id)
        {
            disciplinaModel.Id = id;
            Disciplina disciplina = await _disciplinaRepositorio.AtualizarDisciplina(disciplinaModel, id);
            return Ok(disciplina);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Disciplina>> Apagar(int id)
        {
            bool apagada = await _disciplinaRepositorio.ApagarDisciplina(id);
            return Ok(apagada);
        }
    }
}
