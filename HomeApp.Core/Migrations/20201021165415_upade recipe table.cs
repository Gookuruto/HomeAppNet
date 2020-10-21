using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeApp.Core.Migrations
{
    public partial class upaderecipetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<string>>(
                name: "RecipeMaterials",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipeText",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeMaterials",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeText",
                table: "Recipes");
        }
    }
}
