using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovEstqZdzCodeAPI.Models
{
    [Table("produto")]
    public class Produto
    {
            [Key]
            [Required]
            public int ProdutoID { get; set; }

            [Column("DescricaoProduto")]
            [Required]
            [StringLength(500)]
            public string DescricaoProduto { get; set; }

            [Column("ValorProduto")]
            [Required]
            [Range(0.01, 9999999)]
            public decimal ValorProduto { get; set; }

            [Column("Quantidade")]
            [Required]
            [Range(-10000, 9999999)]
            public int Quantidade { get; set; }

    }
}
