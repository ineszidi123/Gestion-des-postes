using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stage2023.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamillePostes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamillePostes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TypePostes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdFamilleposteFK = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePostes", x => x.id);
                    table.ForeignKey(
                        name: "FK_TypePostes_FamillePostes_IdFamilleposteFK",
                        column: x => x.IdFamilleposteFK,
                        principalTable: "FamillePostes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Postes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTypeposteFK = table.Column<long>(type: "bigint", nullable: false),
                    Nomreseau = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Actif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Postes_TypePostes_IdTypeposteFK",
                        column: x => x.IdTypeposteFK,
                        principalTable: "TypePostes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamillePostes_Code",
                table: "FamillePostes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Postes_IdTypeposteFK",
                table: "Postes",
                column: "IdTypeposteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Postes_Nomreseau",
                table: "Postes",
                column: "Nomreseau",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypePostes_Code",
                table: "TypePostes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypePostes_IdFamilleposteFK",
                table: "TypePostes",
                column: "IdFamilleposteFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postes");

            migrationBuilder.DropTable(
                name: "TypePostes");

            migrationBuilder.DropTable(
                name: "FamillePostes");
        }
    }
}
