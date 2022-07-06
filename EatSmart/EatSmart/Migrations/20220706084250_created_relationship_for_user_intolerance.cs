using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatSmart.Migrations
{
    public partial class created_relationship_for_user_intolerance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intolerances_Users_UserId",
                table: "Intolerances");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Intolerances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Intolerances_Users_UserId",
                table: "Intolerances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intolerances_Users_UserId",
                table: "Intolerances");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Intolerances",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Intolerances_Users_UserId",
                table: "Intolerances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
