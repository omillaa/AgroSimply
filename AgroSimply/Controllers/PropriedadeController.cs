using AgroSimply.Models;
using AgroSimply.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroSimply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropriedadeController : ControllerBase
    {
        // GET: api/<ProdutorController>
        private readonly IPropriedadeRepositorio _propriedadeRepositorio;
        public PropriedadeController(IPropriedadeRepositorio propriedadeRepositorio)
        {

            _propriedadeRepositorio = propriedadeRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropriedadeModels>>> BuscarTodosPropriedade()
        {
            List<PropriedadeModels> propriedade = await _propriedadeRepositorio.BuscarPropriedade();
            return Ok(propriedade);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropriedadeModels>> BuscarPorId(int id)
        {
            PropriedadeModels propriedade = await _propriedadeRepositorio.BuscarPorId(id);
            return Ok(propriedade);
        }
        [HttpPost]
        public async Task<ActionResult<PropriedadeModels>> Cadastrar([FromBody] PropriedadeModels propriedadeModel)
        {
            PropriedadeModels propriedade = await _propriedadeRepositorio.Adicionar(propriedadeModel);
            return Ok(propriedade);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PropriedadeModels>> Atualizar([FromBody] PropriedadeModels propriedadeModel, int id)
        {
            propriedadeModel.IdPropriedade = id;
            PropriedadeModels propriedade = await _propriedadeRepositorio.Atualizar(propriedadeModel, id);
            return Ok(propriedade);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<PropriedadeModels>> Apagar(int id)
        {
            bool apagado = await _propriedadeRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
