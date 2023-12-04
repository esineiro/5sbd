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
        public async Task<ActionResult<List<Inscricao>>> BuscarTodasAsInscricoes()
        {

            List<Inscricao> inscricoes = await _inscricaoRepositorio.BuscarTodasAsInscricoes();
            return Ok(inscricoes);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscricao>> BuscarInscricaoPorId(int id)
        {
            Inscricao inscricao = await _inscricaoRepositorio.BuscarInscricaoPorId(id);
            return Ok(inscricao);
        }
        [HttpPost]
        public async Task<ActionResult<Inscricao>> Cadastrar([FromBody] Inscricao inscricaoModel)
        {
            Inscricao inscricao = await _inscricaoRepositorio.AdicionarInscricao(inscricaoModel);
            return Ok(inscricao);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Inscricao>> Atualizar([FromBody] Inscricao inscricaoModel, int id)
        {
            inscricaoModel.Id = id;
            Inscricao inscricao = await _inscricaoRepositorio.AtualizarInscricao(inscricaoModel, id);
            return Ok(inscricao);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inscricao>> Apagar(int id)
        {
            bool apagada = await _inscricaoRepositorio.ApagarInscricao(id);
            return Ok(apagada);
        }
    }
}
