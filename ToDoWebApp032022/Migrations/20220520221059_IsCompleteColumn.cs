using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoWebApp032022.Migrations
{
    public partial class IsCompleteColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "ToDoItems",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "ToDoItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "ToDoItems");
        }
    }
}
