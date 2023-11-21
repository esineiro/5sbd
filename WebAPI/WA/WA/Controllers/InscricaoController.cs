using Microsoft.AspNetCore.Mvc;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoRepositorio _inscricaoRepositorio;
        public InscricaoController(IInscricaoRepositorio inscricaoRepositorio)
        {
            _inscricaoRepositorio = inscricaoRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<InscricaoModel>>> BuscarTodasAsInscricoes()
        {

            List<InscricaoModel> inscricoes = await _inscricaoRepositorio.BuscarTodasAsInscricoes();
            return Ok(inscricoes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InscricaoModel>> BuscarInscricaoPorId(int id)
        {
            InscricaoModel inscricao = await _inscricaoRepositorio.BuscarInscricaoPorId(id);
            return Ok(inscricao);
        }
        [HttpPost]
        public async Task<ActionResult<InscricaoModel>> Cadastrar([FromBody] InscricaoModel inscricaoModel)
        {
            InscricaoModel inscricao = await _inscricaoRepositorio.AdicionarInscricao(inscricaoModel);
            return Ok(inscricao);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<InscricaoModel>> Atualizar([FromBody] InscricaoModel inscricaoModel, int id)
        {
            inscricaoModel.Id = id;
            InscricaoModel inscricao = await _inscricaoRepositorio.AtualizarInscricao(inscricaoModel, id);
            return Ok(inscricao);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<InscricaoModel>> Apagar(int id)
        {
            bool apagada = await _inscricaoRepositorio.ApagarInscricao(id);
            return Ok(apagada);
        }
    }
}
