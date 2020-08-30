using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Repositories.Migrations
{
    public partial class planner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PlannedBudget",
                table: "Categories",
                type: "decimal(10,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlannedBudget",
                table: "Accounts",
                type: "decimal(10,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedBudget",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PlannedBudget",
                table: "Accounts");
        }
    }
}
