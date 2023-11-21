using Microsoft.AspNetCore.Mvc;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodasAsPessoas() {

            List<PessoaModel> pessoas = await _pessoaRepositorio.BuscarTodasAsPessoas();
            return Ok(pessoas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaModel>> BuscarPessoaPorId(int id)
        {
            PessoaModel pessoa = await _pessoaRepositorio.BuscarPessoaPorId(id);
            return Ok(pessoa);
        }
        [HttpPost]
        public async Task<ActionResult<PessoaModel>> Cadastrar([FromBody] PessoaModel pessoaModel) 
        {
            PessoaModel pessoa = await _pessoaRepositorio.AdicionarPessoa(pessoaModel);
            return Ok(pessoa);  
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaModel>> Atualizar([FromBody] PessoaModel pessoaModel, int id)
        {
            pessoaModel.Id = id;
            PessoaModel pessoa = await _pessoaRepositorio.AtualizarPessoa(pessoaModel, id);
            return Ok(pessoa);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PessoaModel>> Apagar(int id)
        {
            bool apagada = await _pessoaRepositorio.ApagarPessoa(id);
            return Ok(apagada);
        }
    }
}
