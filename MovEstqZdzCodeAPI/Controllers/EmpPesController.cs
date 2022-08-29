using Microsoft.AspNetCore.Mvc;
using MovEstqZdzCodeAPI.Models;
using MovEstqZdzCodeAPI.Service;

namespace MovEstqZdzCodeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpPesController : ControllerBase
    {
        private readonly EmpPesService _empPesService;

        public EmpPesController(EmpPesService empPesService)
        {
            _empPesService = empPesService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var listaEmpPes = _empPesService.ListarEmpPes();
            return Ok(listaEmpPes);
        }

        [HttpPost]
        public IActionResult Salvar([FromBody] EmpPes novoEmpPes)
        {
            _empPesService.SalvarEmpPes(novoEmpPes);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] EmpPes alterarEmpPes)
        {
            _empPesService.EditarEmpPes(alterarEmpPes);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Excluir([FromBody] EmpPes excluirEmpPes)
        {
            _empPesService.DeletarEmpPes(excluirEmpPes);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarProduto(int id)
        {
            return Ok(_empPesService.BuscaPorIdEmpPes(id));
        }
    }
}
