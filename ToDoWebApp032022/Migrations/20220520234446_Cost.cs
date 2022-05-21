using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoWebApp032022.Migrations
{
    public partial class Cost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "ToDoItems",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ToDoItems");
        }
    }
}
