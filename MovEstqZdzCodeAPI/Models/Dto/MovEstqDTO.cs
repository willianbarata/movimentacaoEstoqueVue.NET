namespace MovEstqZdzCodeAPI.Models.Dto
{
    public class MovEstqDTO
    {
        public int MovEstqID { get; set; }
        public int EmpPesID { get; set; }
        public decimal ValorTotal { get; set; }
        public string EntradaSaida { get; set; }
        public List<ItemMovEstoque> itemMovEstoques { get; set; }
    }
}
