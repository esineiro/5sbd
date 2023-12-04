using Microsoft.AspNetCore.Mvc;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController(IPessoaRepositorio pessoaRepositorio) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> BuscarTodasAsPessoas() {

            List<Pessoa> pessoas = await pessoaRepositorio.BuscarTodasAsPessoas();
            return Ok(pessoas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> BuscarPessoaPorId(int id)
        {
            Pessoa pessoa = await pessoaRepositorio.BuscarPessoaPorId(id);
            return Ok(pessoa);
        }
        [HttpPost]
        public async Task<ActionResult<Pessoa>> Cadastrar([FromBody] Pessoa pessoaModel) 
        {
            Pessoa pessoa = await pessoaRepositorio.AdicionarPessoa(pessoaModel);
            return Ok(pessoa);  
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Pessoa>> Atualizar([FromBody] Pessoa pessoaModel, int id)
        {
            pessoaModel.Id = id;
            Pessoa pessoa = await pessoaRepositorio.AtualizarPessoa(pessoaModel, id);
            return Ok(pessoa);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> Apagar(int id)
        {
            bool apagada = await pessoaRepositorio.ApagarPessoa(id);
            return Ok(apagada);
        }
    }
}
