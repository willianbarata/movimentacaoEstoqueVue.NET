using MovEstqZdzCodeAPI.Models;
using MovEstqZdzCodeAPI.Models.Context;
using MovEstqZdzCodeAPI.Models.Dto;

namespace MovEstqZdzCodeAPI.Service
{
    public class MovEstqService
    {
        private readonly MySqlContext _conexao;

        private readonly ItemMovEstqService _itemMovEstqService;
        public MovEstqService(MySqlContext conexao, ItemMovEstqService itemMovEstqService)
        {
            _conexao = conexao;
            _itemMovEstqService = itemMovEstqService;
        }

        public void SalvarMovEstq(MovEstqDTO movestq)
        {
            MovEstoque movimentacao = new MovEstoque();
            movimentacao.EmpPesID = movestq.EmpPesID;
            movimentacao.EntradaSaida = movestq.EntradaSaida;
            movimentacao.ValorTotal = movestq.ValorTotal;

            
            _conexao.MovEstoque.Add(movimentacao);

            List<ItemMovEstoque> listaItem = new List<ItemMovEstoque>();

            foreach (var item in movestq.itemMovEstoques)
            {
                ItemMovEstoque itemMovEstq = new ItemMovEstoque();
                itemMovEstq.MovEstoqueID = item.MovEstoqueID;
                itemMovEstq.Quantidade = item.Quantidade;
                itemMovEstq.ValorUnitario = item.ValorUnitario;
                itemMovEstq.ProdutoID = item.ProdutoID;
                _itemMovEstqService.SalvarItemMovEstq(itemMovEstq);
            }
            
            _conexao.SaveChanges();
        }
    }
}
