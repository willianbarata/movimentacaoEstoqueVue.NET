using MovEstqZdzCodeAPI.Models;
using MovEstqZdzCodeAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace MovEstqZdzCodeAPI.Service
{
    public class ProdutoService
    {
        private readonly MySqlContext _conexao;

        public ProdutoService(MySqlContext conexao)
        {
            _conexao = conexao;
        }

        public IEnumerable<Produto> ListarProduto()
        {
            return  _conexao.Produto;
        }

        public void SalvarProduto(Produto novoProduto)
        {
            _conexao.Produto.Add(novoProduto);
            _conexao.SaveChanges();
        }

        public void EditarProduto(Produto produto)
        {
            _conexao.Produto.Update(produto);
            _conexao.SaveChanges();
        }

        public void DeletarProduto(Produto produto)
        {
            _conexao.Produto.Remove(produto);
            _conexao.SaveChanges();
        }

        public Produto BuscaPorIdProduto(int id)
        {
            return _conexao.Produto.FirstOrDefault(obj => obj.ProdutoID == id);
        }
    }
}
