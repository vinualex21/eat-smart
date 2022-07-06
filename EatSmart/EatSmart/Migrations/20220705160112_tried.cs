using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatSmart.Migrations
{
    public partial class tried : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intolerances_Users_UserId",
                table: "Intolerances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Intolerances",
                table: "Intolerances");

            migrationBuilder.RenameTable(
                name: "Intolerances",
                newName: "Intolerance");

            migrationBuilder.RenameIndex(
                name: "IX_Intolerances_UserId",
                table: "Intolerance",
                newName: "IX_Intolerance_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Intolerance",
                table: "Intolerance",
                column: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Intolerance_Users_UserId",
                table: "Intolerance",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intolerance_Users_UserId",
                table: "Intolerance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Intolerance",
                table: "Intolerance");

            migrationBuilder.RenameTable(
                name: "Intolerance",
                newName: "Intolerances");

            migrationBuilder.RenameIndex(
                name: "IX_Intolerance_UserId",
                table: "Intolerances",
                newName: "IX_Intolerances_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Intolerances",
                table: "Intolerances",
                column: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Intolerances_Users_UserId",
                table: "Intolerances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
