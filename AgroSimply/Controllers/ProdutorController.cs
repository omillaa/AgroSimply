using AgroSimply.Models;
using AgroSimply.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgroSimply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutorController : ControllerBase
    {
        // GET: api/<ProdutorController>
        private readonly IProdutorRepositorio _produtorRepositorio;
        public ProdutorController(IProdutorRepositorio produtorRepositorio)
        {
            _produtorRepositorio = produtorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutorModels>>> BuscarTodosProdutores()
        {
          List<ProdutorModels> produtor =  await _produtorRepositorio.BuscarProdutor();
            return Ok(produtor);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutorModels>> BuscarPorId(int id)
        {
            ProdutorModels produtor = await _produtorRepositorio.BuscarPorId(id);
            return Ok(produtor);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutorModels>> Cadastrar([FromBody] ProdutorModels produtorModel)
        {
           ProdutorModels produtor = await _produtorRepositorio.Adicionar(produtorModel);
            return Ok(produtor);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutorModels>> Atualizar([FromBody] ProdutorModels produtorModel,int id)
        {
            produtorModel.IdProdutor = id;
            ProdutorModels produtor = await _produtorRepositorio.Atualizar(produtorModel, id);
            return Ok(produtor);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<ProdutorModels>> Apagar(int id)
        {
            bool apagado = await _produtorRepositorio.Apagar(id);   
            return Ok(apagado);
        }
    }
}
