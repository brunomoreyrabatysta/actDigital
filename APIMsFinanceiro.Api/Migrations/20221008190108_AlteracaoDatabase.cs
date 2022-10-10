using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMsFinanceiro.Migrations
{
    public partial class AlteracaoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Cilente_ClienteId",
                table: "Lancamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cilente",
                table: "Cilente");

            migrationBuilder.RenameTable(
                name: "Cilente",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Cliente_ClienteId",
                table: "Lancamento",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamento_Cliente_ClienteId",
                table: "Lancamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Cilente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cilente",
                table: "Cilente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamento_Cilente_ClienteId",
                table: "Lancamento",
                column: "ClienteId",
                principalTable: "Cilente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
