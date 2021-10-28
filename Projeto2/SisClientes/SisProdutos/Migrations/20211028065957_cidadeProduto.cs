using Microsoft.EntityFrameworkCore.Migrations;

namespace SisProdutos.Migrations
{
    public partial class cidadeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CidadeIdCidade",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CidadeResponse",
                columns: table => new
                {
                    IdCidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CidadeResponse", x => x.IdCidade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CidadeIdCidade",
                table: "Produtos",
                column: "CidadeIdCidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_CidadeResponse_CidadeIdCidade",
                table: "Produtos",
                column: "CidadeIdCidade",
                principalTable: "CidadeResponse",
                principalColumn: "IdCidade",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_CidadeResponse_CidadeIdCidade",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "CidadeResponse");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CidadeIdCidade",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CidadeIdCidade",
                table: "Produtos");
        }
    }
}
