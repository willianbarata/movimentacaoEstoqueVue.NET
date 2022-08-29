using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovEstqZdzCodeAPI.Models
{
    [Table("EmpPes")]
    public class EmpPes
    {
        [Key]
        [Required]
        public int EmpPesID { get; set; }

        [Required(ErrorMessage = "Favor informar o nome da empresa")]
        [StringLength(100)]
        public string NomeEmpPes { get; set; }

        [Required(ErrorMessage = "Favor informar se é Cliente ou Fornecedor")]
        [StringLength(10)]
        public string ClienteFornecedor { get; set; }

        [Required(ErrorMessage = "Favor informar CNPJ ou CPF")]
        [StringLength(20)]
        public string CnpjCpf { get; set; }

        [Required(ErrorMessage = "Favor informar se é Físico ou Jurídico")]
        [StringLength(8)]
        public string FisicoJuridico { get; set; }

    }
}
