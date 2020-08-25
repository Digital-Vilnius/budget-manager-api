using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Repositories.Migrations
{
    public partial class Spentby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpentById",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SpentById",
                table: "Transactions",
                column: "SpentById");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AccountUsers_SpentById",
                table: "Transactions",
                column: "SpentById",
                principalTable: "AccountUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AccountUsers_SpentById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SpentById",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SpentById",
                table: "Transactions");
        }
    }
}
