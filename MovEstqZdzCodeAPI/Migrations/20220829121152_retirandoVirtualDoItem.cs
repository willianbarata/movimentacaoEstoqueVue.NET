using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovEstqZdzCodeAPI.Migrations
{
    public partial class retirandoVirtualDoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMovEstoque_MovEstoque_MovEstoqueID",
                table: "ItemMovEstoque");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMovEstoque_produto_ProdutoID",
                table: "ItemMovEstoque");

            migrationBuilder.DropIndex(
                name: "IX_ItemMovEstoque_MovEstoqueID",
                table: "ItemMovEstoque");

            migrationBuilder.DropIndex(
                name: "IX_ItemMovEstoque_ProdutoID",
                table: "ItemMovEstoque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemMovEstoque_MovEstoqueID",
                table: "ItemMovEstoque",
                column: "MovEstoqueID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMovEstoque_ProdutoID",
                table: "ItemMovEstoque",
                column: "ProdutoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMovEstoque_MovEstoque_MovEstoqueID",
                table: "ItemMovEstoque",
                column: "MovEstoqueID",
                principalTable: "MovEstoque",
                principalColumn: "MovEstqID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMovEstoque_produto_ProdutoID",
                table: "ItemMovEstoque",
                column: "ProdutoID",
                principalTable: "produto",
                principalColumn: "ProdutoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
