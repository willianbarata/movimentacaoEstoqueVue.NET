using MovEstqZdzCodeAPI.Models;
using MovEstqZdzCodeAPI.Models.Context;

namespace MovEstqZdzCodeAPI.Service
{
    public class ItemMovEstqService
    {
        private readonly MySqlContext _conexao;
        public ItemMovEstqService(MySqlContext conexao)
        {
            _conexao = conexao;
        }

        public void SalvarItemMovEstq(ItemMovEstoque item)
        {
                _conexao.ItemMovEstoque.Add(item);
                _conexao.SaveChanges();
        }
    }
}
