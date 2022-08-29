using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovEstqZdzCodeAPI.Migrations
{
    public partial class incluindoQuantidadeNoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "produto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "produto");
        }
    }
}
