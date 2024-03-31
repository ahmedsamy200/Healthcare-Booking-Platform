using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class removeRoleTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Role_roleID",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_roleID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_User_roleID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_roleID",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "roleID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "roleID",
                table: "Doctor");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Doctor");

            migrationBuilder.AddColumn<int>(
                name: "roleID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "roleID",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_roleID",
                table: "User",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_roleID",
                table: "Doctor",
                column: "roleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Role_roleID",
                table: "Doctor",
                column: "roleID",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_roleID",
                table: "User",
                column: "roleID",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
