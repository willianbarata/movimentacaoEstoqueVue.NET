using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovEstqZdzCodeAPI.Models
{
    [Table("MovEstoque")]
    public class MovEstoque
    {
        [Key]
        [Required]
        public int MovEstqID { get; set; }

        public int EmpPesID { get; set; }
        public virtual EmpPes EmpPes { get; set; }

        [Column("ValorTotal")]
        [Required]
        [Range(0.01, 10000)]
        public decimal ValorTotal { get; set; }

        [Column("EntradaSaida")]
        [Required]
        [StringLength(7)]
        public string EntradaSaida { get; set; }

    }
}
