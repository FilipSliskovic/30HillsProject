using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _30HillsProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixedUserPasswordBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUseCases",
                table: "UserUseCases");

            migrationBuilder.DropIndex(
                name: "IX_UserUseCases_UserId",
                table: "UserUseCases");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserUseCases");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUseCases",
                table: "UserUseCases",
                columns: new[] { "UserId", "UseCaseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUseCases",
                table: "UserUseCases");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserUseCases",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUseCases",
                table: "UserUseCases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserUseCases_UserId",
                table: "UserUseCases",
                column: "UserId");
        }
    }
}
