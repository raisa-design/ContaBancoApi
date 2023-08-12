using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContaBancoApi.Migrations
{
    public partial class agenciaconta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgenciaId",
                table: "contasBancarias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "agencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Saldo = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agencias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contasBancarias_AgenciaId",
                table: "contasBancarias",
                column: "AgenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_contasBancarias_agencias_AgenciaId",
                table: "contasBancarias",
                column: "AgenciaId",
                principalTable: "agencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contasBancarias_agencias_AgenciaId",
                table: "contasBancarias");

            migrationBuilder.DropTable(
                name: "agencias");

            migrationBuilder.DropIndex(
                name: "IX_contasBancarias_AgenciaId",
                table: "contasBancarias");

            migrationBuilder.DropColumn(
                name: "AgenciaId",
                table: "contasBancarias");
        }
    }
}
