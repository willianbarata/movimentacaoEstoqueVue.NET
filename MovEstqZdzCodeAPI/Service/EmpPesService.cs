using MovEstqZdzCodeAPI.Models;
using MovEstqZdzCodeAPI.Models.Context;

namespace MovEstqZdzCodeAPI.Service
{
    public class EmpPesService
    {
        private readonly MySqlContext _conexao;

        public EmpPesService(MySqlContext conexao)
        {
            _conexao = conexao;
        }

        public IEnumerable<EmpPes> ListarEmpPes()
        {
            return _conexao.EmpPes;
        }

        public void SalvarEmpPes(EmpPes empPes)
        {
            _conexao.EmpPes.Add(empPes);
            _conexao.SaveChanges();
        }

        public void EditarEmpPes(EmpPes empPes)
        {
            _conexao.EmpPes.Update(empPes);
            _conexao.SaveChanges();
        }

        public void DeletarEmpPes(EmpPes empPes)
        {
            _conexao.EmpPes.Remove(empPes);
            _conexao.SaveChanges();
        }

        public EmpPes BuscaPorIdEmpPes(int id)
        {
            return _conexao.EmpPes.FirstOrDefault(obj => obj.EmpPesID == id);
        }
    }
}
