using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovEstqZdzCodeAPI.Models
{
    public class ItemMovEstoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemMovEstoqueID { get; set; }
        public int MovEstoqueID { get; set; }

        [Column("Quantidade")]
        [Range(1, 9999999)]
        public int Quantidade { get; set; }

        [Column("ValorUnitario")]
        [Required]
        [Range(0.01, 10000)]
        public decimal ValorUnitario { get; set; }
        public int ProdutoID { get; set; }

    }
}
