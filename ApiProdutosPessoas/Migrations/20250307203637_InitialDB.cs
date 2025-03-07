using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiProdutosPessoas.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Cod_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Cod_Marca);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Cod_Marca = table.Column<int>(type: "int", nullable: false),
                    MarcaModelCodigoMarca = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Produtos_Marcas_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Marcas",
                        principalColumn: "Cod_Marca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Marcas_MarcaModelCodigoMarca",
                        column: x => x.MarcaModelCodigoMarca,
                        principalTable: "Marcas",
                        principalColumn: "Cod_Marca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_MarcaModelCodigoMarca",
                table: "Produtos",
                column: "MarcaModelCodigoMarca");
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
