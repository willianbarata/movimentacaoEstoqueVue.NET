using Microsoft.AspNetCore.Mvc;
using MovEstqZdzCodeAPI.Service;
using MovEstqZdzCodeAPI.Models;

namespace MovEstqZdzCodeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var listaProduto = _produtoService.ListarProduto();
            return Ok(listaProduto);
        }

        [HttpPost]
        public IActionResult Salvar([FromBody] Produto novoProduto)
        {           
            _produtoService.SalvarProduto(novoProduto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] Produto alterarProduto)
        {
            _produtoService.EditarProduto(alterarProduto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Excluir([FromBody] Produto excluirProduto)
        {
            _produtoService.DeletarProduto(excluirProduto);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarProduto(int id)
        {
            return Ok(_produtoService.BuscaPorIdProduto(id));
        }
    }
}
