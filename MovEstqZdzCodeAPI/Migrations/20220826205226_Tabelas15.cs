using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovEstqZdzCodeAPI.Migrations
{
    public partial class Tabelas15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmpPes",
                columns: table => new
                {
                    EmpPesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeEmpPes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteFornecedor = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CnpjCpf = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FisicoJuridico = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpPes", x => x.EmpPesID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    ProdutoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescricaoProduto = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorProduto = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.ProdutoID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovEstoque",
                columns: table => new
                {
                    MovEstqID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpPesID = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    EntradaSaida = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovEstoque", x => x.MovEstqID);
                    table.ForeignKey(
                        name: "FK_MovEstoque_EmpPes_EmpPesID",
                        column: x => x.EmpPesID,
                        principalTable: "EmpPes",
                        principalColumn: "EmpPesID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemMovEstoque",
                columns: table => new
                {
                    ItemMovEstoqueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovEstoqueID = table.Column<int>(type: "int", nullable: false),
                    Sequencia = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMovEstoque", x => x.ItemMovEstoqueID);
                    table.ForeignKey(
                        name: "FK_ItemMovEstoque_MovEstoque_MovEstoqueID",
                        column: x => x.MovEstoqueID,
                        principalTable: "MovEstoque",
                        principalColumn: "MovEstqID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemMovEstoque_produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "produto",
                        principalColumn: "ProdutoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMovEstoque_MovEstoqueID",
                table: "ItemMovEstoque",
                column: "MovEstoqueID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMovEstoque_ProdutoID",
                table: "ItemMovEstoque",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_MovEstoque_EmpPesID",
                table: "MovEstoque",
                column: "EmpPesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMovEstoque");

            migrationBuilder.DropTable(
                name: "MovEstoque");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "EmpPes");
        }
    }
}
