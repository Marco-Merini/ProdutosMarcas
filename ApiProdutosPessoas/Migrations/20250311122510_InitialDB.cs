using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiProdutosPessoas_Test.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    CodigoMarca = table.Column<int>(type: "int", nullable: false),
                    DescricaoMarca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.CodigoMarca);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    CodigoProduto = table.Column<int>(type: "int", nullable: false),
                    DescricaoProduto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EstoqueProduto = table.Column<int>(type: "int", nullable: false),
                    CodigoMarca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.CodigoProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Marcas_CodigoMarca",
                        column: x => x.CodigoMarca,
                        principalTable: "Marcas",
                        principalColumn: "CodigoMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoMarca",
                table: "Produtos",
                column: "CodigoMarca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
