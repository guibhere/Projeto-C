using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_C_.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Diretores_DiretorId1",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_DiretorId1",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "DiretorId1",
                table: "Filmes");

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes",
                column: "DiretorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes",
                column: "DiretorId",
                principalTable: "Diretores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes");

            migrationBuilder.AddColumn<int>(
                name: "DiretorId1",
                table: "Filmes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId1",
                table: "Filmes",
                column: "DiretorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Diretores_DiretorId1",
                table: "Filmes",
                column: "DiretorId1",
                principalTable: "Diretores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
