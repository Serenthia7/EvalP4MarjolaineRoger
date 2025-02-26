using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    IdApplication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.IdApplication);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    IdPassword = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdApplication = table.Column<int>(type: "int", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.IdPassword);
                    table.ForeignKey(
                        name: "FK_Passwords_Applications_IdApplication",
                        column: x => x.IdApplication,
                        principalTable: "Applications",
                        principalColumn: "IdApplication",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_IdApplication",
                table: "Passwords",
                column: "IdApplication");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
