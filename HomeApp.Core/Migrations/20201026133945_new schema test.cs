using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeApp.Core.Migrations
{
    public partial class newschematest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Savings",
                newName: "Savings",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "RecipesProductQuantity",
                newName: "RecipesProductQuantity",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipes",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Incomes",
                newName: "Incomes",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "BillsType",
                newName: "BillsType",
                newSchema: "core");

            migrationBuilder.RenameTable(
                name: "Bills",
                newName: "Bills",
                newSchema: "core");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "core",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Savings",
                schema: "core",
                newName: "Savings");

            migrationBuilder.RenameTable(
                name: "RecipesProductQuantity",
                schema: "core",
                newName: "RecipesProductQuantity");

            migrationBuilder.RenameTable(
                name: "Recipes",
                schema: "core",
                newName: "Recipes");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "core",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Incomes",
                schema: "core",
                newName: "Incomes");

            migrationBuilder.RenameTable(
                name: "BillsType",
                schema: "core",
                newName: "BillsType");

            migrationBuilder.RenameTable(
                name: "Bills",
                schema: "core",
                newName: "Bills");
        }
    }
}
