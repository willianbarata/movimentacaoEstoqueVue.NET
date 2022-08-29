using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovEstqZdzCodeAPI.Migrations
{
    public partial class retirandoVirtualDoItem1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequencia",
                table: "ItemMovEstoque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sequencia",
                table: "ItemMovEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
