using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroSimply.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtor",
                columns: table => new
                {
                    IdProdutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CPF = table.Column<double>(type: "float", maxLength: 11, nullable: false),
                    CNPJ = table.Column<double>(type: "float", maxLength: 14, nullable: false),
                    Telefone = table.Column<double>(type: "float", maxLength: 12, nullable: false),
                    Atividade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtor", x => x.IdProdutor);
                });

            migrationBuilder.CreateTable(
                name: "Propriedade",
                columns: table => new
                {
                    IdPropriedade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProdutor = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Extensão = table.Column<float>(type: "real", maxLength: 255, nullable: false),
                    Cultura = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propriedade", x => x.IdPropriedade);
                    table.ForeignKey(
                        name: "FK_Propriedade_Produtor_IdProdutor",
                        column: x => x.IdProdutor,
                        principalTable: "Produtor",
                        principalColumn: "IdProdutor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propriedade_IdProdutor",
                table: "Propriedade",
                column: "IdProdutor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propriedade");

            migrationBuilder.DropTable(
                name: "Produtor");
        }
    }
}
