using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RenomeandoCampoNomeShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeShow",
                table: "Shows",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Shows",
                newName: "NomeShow");
        }
    }
}
